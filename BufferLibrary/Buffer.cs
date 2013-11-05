using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBuffer {
    public class Buffer {
        public static string VERSION = "1.1";
        static string before = "";
        static string after = "";

        public static void Write(string t) {
            after += t;
        }

        public static void WriteLine(string t) {
            after += t + "\n";
        }

        public static void WriteLineCenter(string t) {
            WriteLine(String.Format("{0," + (Console.WindowWidth / 2 + t.Length / 2 + t.Split('§').Length) + "}", t));
        }

        public static void Clear() {
            if (before != after) {
                Console.Clear();
                String[] parts = after.Split('§');
                Console.Write(parts[0]);
                for (int i = 1;i < parts.Length;i++) {
                    String part = parts[i];
                    Console.ForegroundColor = HEXToColor(part.Substring(0,1));
                    Console.BackgroundColor = HEXToColor(part.Substring(1,1));
                    Console.Write(part.Substring(2));
                }
                before = after;
            }
            after = "";
        }

        private static string ColorToHEX(ConsoleColor c) {
            switch (c) {
                default:
                    return "0";
                case ConsoleColor.Blue:
                    return "1";
                case ConsoleColor.Cyan:
                    return "2";
                case ConsoleColor.DarkBlue:
                    return "3";
                case ConsoleColor.DarkCyan:
                    return "4";
                case ConsoleColor.DarkGray:
                    return "5";
                case ConsoleColor.DarkGreen:
                    return "6";
                case ConsoleColor.DarkMagenta:
                    return "7";
                case ConsoleColor.DarkRed:
                    return "8";
                case ConsoleColor.DarkYellow:
                    return "9";
                case ConsoleColor.Gray:
                    return "A";
                case ConsoleColor.Green:
                    return "B";
                case ConsoleColor.Magenta:
                    return "C";
                case ConsoleColor.Red:
                    return "D";
                case ConsoleColor.White:
                    return "E";
                case ConsoleColor.Yellow:
                    return "F";
            }
        }

        private static ConsoleColor HEXToColor(String h) {
            switch (h) {
                default:
                    return ConsoleColor.Black;
                case "1":
                    return ConsoleColor.Blue;
                case "2":
                    return ConsoleColor.Cyan;
                case "3":
                    return ConsoleColor.DarkBlue;
                case "4":
                    return ConsoleColor.DarkCyan;
                case "5":
                    return ConsoleColor.DarkGray;
                case "6":
                    return ConsoleColor.DarkGreen;
                case "7":
                    return ConsoleColor.DarkMagenta;
                case "8":
                    return ConsoleColor.DarkRed;
                case "9":
                    return ConsoleColor.DarkYellow;
                case "A":
                    return ConsoleColor.Gray;
                case "B":
                    return ConsoleColor.Green;
                case "C":
                    return ConsoleColor.Magenta;
                case "D":
                    return ConsoleColor.Red;
                case "E":
                    return ConsoleColor.White;
                case "F":
                    return ConsoleColor.Yellow;
            }
        }

        public static void SetColor(ConsoleColor foreground,ConsoleColor background) {
            after += "§" + ColorToHEX(foreground) + ColorToHEX(background);
        }

        public static string GetColorString(ConsoleColor foreground,ConsoleColor background) {
            return "§" + ColorToHEX(foreground) + ColorToHEX(background);
        }

        public static string GetBuffer(bool old = false) {
            return old ? before : after;
        }
    }
}
