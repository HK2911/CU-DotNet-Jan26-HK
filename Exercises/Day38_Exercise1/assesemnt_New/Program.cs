using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assesemnt_New
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
                string s = Console.ReadLine();
                s = s.ToLower();
            
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < s.Length; i++)
                {
                char ch = s[i];
                if (ch == 'a')
                    sb.Append('e');
                else if (ch == 'e')
                    sb.Append('i');
                else if (ch == 'i')
                    sb.Append('o');
                else if (ch == 'o')
                    sb.Append('u');
                else if (ch == 'u')
                    sb.Append('a');
                else
                   { 
                    if(++ch=='a'|| ch == 'e'|| ch == 'i'|| ch == 'o'|| ch == 'u')
                    {
                        
                        sb.Append(++ch); 
                    }
                   else
                    {
                        sb.Append(ch);
                    }
                }
             
                }
                Console.WriteLine(sb.ToString());

            
        }
    }
}
