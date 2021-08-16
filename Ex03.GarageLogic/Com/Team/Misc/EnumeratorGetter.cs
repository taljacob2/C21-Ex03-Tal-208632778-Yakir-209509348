﻿#region

 using System.Collections;

 #endregion

namespace Ex03.GarageLogic.Com.Team.Misc
{
    public static class EnumeratorGetter // TODO: check if required.
    {
        public static IEnumerator GetEnumerator(object i_Container)
        {
            foreach (object o in (IEnumerable) i_Container)
            {
                if (o == null)
                {
                    break;
                }

                yield return o;
            }
        }
    }
}
