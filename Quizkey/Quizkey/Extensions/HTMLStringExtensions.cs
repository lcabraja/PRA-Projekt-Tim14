using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizkey
{
    public static class HTMLStringExtensions
    {
        public static string ToBold(this string baseString)
        {
            return $"<b>{baseString}</b>";
        }
        public static string ToStrong(this string baseString)
        {
            return $"<strong>{baseString}</strong>";
        }
        public static string ToItalic(this string baseString)
        {
            return $"<i>{baseString}</i>";
        }
        public static string ToEmphasized(this string baseString)
        {
            return $"<em>{baseString}</em>";
        }
        public static string ToMarked(this string baseString)
        {
            return $"<mark>{baseString}</mark>";
        }
        public static string ToSmaller(this string baseString)
        {
            return $"<small>{baseString}</small>";
        }
        public static string ToDeleted(this string baseString)
        {
            return $"<del>{baseString}</del>";
        }
        public static string ToInserted(this string baseString)
        {
            return $"<ins>{baseString}</ins>";
        }
        public static string ToSubscript(this string baseString)
        {
            return $"<sub>{baseString}</sub>";
        }
        public static string ToSuperscript(this string baseString)
        {
            return $"<sup>{baseString}</sup>";
        }
        public static string ToBadge(this string baseString, string color = null)
        {
            return $"<span class=\"badge bg-{color ?? "primary"}\">{baseString}</span>";
        }
        public static string ToGenericTag(this string baseString, string tag, string values = null)
        {
            return $"<{tag}{(values != null ? $" {values}" : string.Empty)}>{baseString}</{tag}>";
        }
    }
}