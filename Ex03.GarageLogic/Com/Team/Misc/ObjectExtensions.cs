﻿#region

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Ex03.GarageLogic.Com.Team.Misc.ArrayExtensions;

#endregion

namespace Ex03.GarageLogic.Com.Team.Misc
{
    public static class ObjectExtensions // TODO: check if required.
    {
        private static readonly MethodInfo sr_CloneMethod =
            typeof(object).GetMethod("MemberwiseClone",
                BindingFlags.NonPublic | BindingFlags.Instance);

        public static string ToStringExtension(this object i_Obj)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int i = 0;
            stringBuilder.Append("{");
            foreach (PropertyInfo property in i_Obj.GetType().GetProperties())
            {
                stringBuilder.Append(property.Name);
                stringBuilder.Append(": ");
                if (property.GetIndexParameters().Length > 0)
                {
                    stringBuilder.Append("Indexed Property cannot be used");
                }
                else
                {
                    stringBuilder.Append(property.GetValue(i_Obj, null));
                }

                i++;

                if (i < i_Obj.GetType().GetProperties().Length)
                {
                    // stringBuilder.Append(Environment.NewLine);
                    stringBuilder.Append(", ");
                }
            }

            stringBuilder.Append("}");

            return stringBuilder.ToString();
        }

        public static bool IsPrimitive(this Type i_Type)
        {
            return i_Type == typeof(string) ||
                   i_Type.IsValueType & i_Type.IsPrimitive;
        }

        public static object Copy(this object i_OriginalObject)
        {
            return internalCopy(i_OriginalObject,
                new Dictionary<object, object>(
                    new ReferenceEqualityComparer()));
        }

        // ReSharper disable once ExcessiveIndentation
        // ReSharper disable once MethodTooLong
        private static object internalCopy(object i_OriginalObject,
            IDictionary<object, object> i_Visited)
        {
            object returnValue = null;
            Type typeToReflect = i_OriginalObject.GetType();

            if (i_OriginalObject == null)
            {
                returnValue = null;
            }
            else if (IsPrimitive(typeToReflect))
            {
                returnValue = i_OriginalObject;
            }
            else if (i_Visited.ContainsKey(i_OriginalObject))
            {
                returnValue = i_Visited[i_OriginalObject];
            }
            else if (typeof(Delegate).IsAssignableFrom(typeToReflect))
            {
                returnValue = null;
            }
            else
            {
                returnValue = internalCopyElseBranch(i_OriginalObject,
                    i_Visited, typeToReflect);
            }

            return returnValue;
        }

        private static object internalCopyElseBranch(object i_OriginalObject,
            IDictionary<object, object> i_Visited, Type i_TypeToReflect)
        {
            object returnValue;
            object cloneObject =
                sr_CloneMethod.Invoke(i_OriginalObject, null);
            if (i_TypeToReflect.IsArray)
            {
                Type arrayType = i_TypeToReflect.GetElementType();
                if (IsPrimitive(arrayType) == false)
                {
                    Array clonedArray = (Array) cloneObject;
                    clonedArray.ForEach((i_Array, i_Indices) =>
                        i_Array.SetValue(
                            internalCopy(clonedArray.GetValue(i_Indices),
                                i_Visited), i_Indices));
                }
            }

            i_Visited.Add(i_OriginalObject, cloneObject);
            copyFields(i_OriginalObject, i_Visited, cloneObject,
                i_TypeToReflect);
            recursiveCopyBaseTypePrivateFields(i_OriginalObject, i_Visited,
                cloneObject, i_TypeToReflect);

            returnValue = cloneObject;
            return returnValue;
        }

        // ReSharper disable once TooManyArguments
        private static void recursiveCopyBaseTypePrivateFields(
            object i_OriginalObject, IDictionary<object, object> i_Visited,
            object i_CloneObject, Type i_TypeToReflect)
        {
            if (i_TypeToReflect.BaseType != null)
            {
                recursiveCopyBaseTypePrivateFields(i_OriginalObject, i_Visited,
                    i_CloneObject, i_TypeToReflect.BaseType);
                copyFields(i_OriginalObject, i_Visited, i_CloneObject,
                    i_TypeToReflect.BaseType,
                    BindingFlags.Instance | BindingFlags.NonPublic,
                    i_Info => i_Info.IsPrivate);
            }
        }

        // ReSharper disable once TooManyArguments
        private static void copyFields(object i_OriginalObject,
            IDictionary<object, object> i_Visited, object i_CloneObject,
            Type i_TypeToReflect,
            BindingFlags i_BindingFlags =
                BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public | BindingFlags.FlattenHierarchy,
            Func<FieldInfo, bool> i_Filter = null)
        {
            foreach (FieldInfo fieldInfo in i_TypeToReflect.GetFields(
                i_BindingFlags))
            {
                if (i_Filter?.Invoke(fieldInfo) == false)
                {
                    continue;
                }

                if (IsPrimitive(fieldInfo.FieldType))
                {
                    continue;
                }

                object originalFieldValue =
                    fieldInfo.GetValue(i_OriginalObject);
                object clonedFieldValue =
                    internalCopy(originalFieldValue, i_Visited);
                fieldInfo.SetValue(i_CloneObject, clonedFieldValue);
            }
        }

        public static T Copy<T>(this T i_Original)
        {
            return (T) Copy((object) i_Original);
        }
    }

    public class ReferenceEqualityComparer : EqualityComparer<object>
    {
        public override bool Equals(object i_X, object i_Y)
        {
            return ReferenceEquals(i_X, i_Y);
        }

        public override int GetHashCode(object i_Obj)
        {
            return i_Obj == null ? 0 : i_Obj.GetHashCode();
        }
    }

    namespace ArrayExtensions
    {
        public static class ArrayExtensions
        {
            public static void ForEach(this Array i_Array,
                Action<Array, int[]> i_Action)
            {
                if (i_Array.LongLength == 0)
                {
                    return;
                }

                ArrayTraverse walker = new ArrayTraverse(i_Array);
                do
                {
                    i_Action(i_Array, walker.m_Position);
                } while (walker.Step());
            }
        }

        internal class ArrayTraverse
        {
            private readonly int[] r_MaxLengths;
            public int[] m_Position;

            public ArrayTraverse(Array i_Array)
            {
                r_MaxLengths = new int[i_Array.Rank];

                for (int i = 0; i < i_Array.Rank; ++i)
                {
                    r_MaxLengths[i] = i_Array.GetLength(i) - 1;
                }

                m_Position = new int[i_Array.Rank];
            }

            public bool Step()
            {
                bool returnValue = false;

                for (int i = 0; i < m_Position.Length; ++i)
                {
                    if (m_Position[i] >= r_MaxLengths[i])
                    {
                        continue;
                    }

                    m_Position[i]++;
                    for (int j = 0; j < i; j++)
                    {
                        m_Position[j] = 0;
                    }

                    returnValue = true;
                    break;
                }

                return returnValue;
            }
        }
    }
}
