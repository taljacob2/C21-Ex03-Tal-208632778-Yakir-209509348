﻿using System;
using System.Text;

namespace Ex03.ConsoleUI.Com.Team.Misc
{
    public static class StringIndentation
    {
        public static void NewIndentLine(StringBuilder io_StringBuilder,
            int i_IndentationLevel)
        {
            io_StringBuilder.Append(Environment.NewLine);
            io_StringBuilder.Append(IndentationString(i_IndentationLevel));
        }

        public static string IndentationString(int i_IndentationLevel)
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
