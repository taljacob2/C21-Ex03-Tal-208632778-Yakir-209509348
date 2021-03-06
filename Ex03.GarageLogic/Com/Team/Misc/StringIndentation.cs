using System;
using System.Text;

namespace Ex03.GarageLogic.Com.Team.Misc
{
    public static class StringIndentation
    {
        public static void NewLine(StringBuilder io_StringBuilder,
            int i_IndentationLevel)
        {
            io_StringBuilder.Append(Environment.NewLine);
            io_StringBuilder.Append(Create(i_IndentationLevel));
        }

        public static string Create(int i_IndentationLevel)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 1; i <= i_IndentationLevel; i++)
            {
                builder.Append("    ");
            }

            return builder.ToString();
        }
    }
}
