using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ja_projekt
{
    internal class CSV
    {
        private string str;
        private bool luhn = false;

        public CSV(String newStr, Boolean newLuhn)
        {
            this.SetString(newStr);
            this.SetLuhn(newLuhn);
        }

        public void SetString(String newStr)
        {
            if(newStr.Length == 16) {
                this.str = newStr;
            } else if(newStr.Length > 16) {
                this.str = newStr.Substring(0, 16);
            } else { 
                int offsett = 16 - newStr.Length;
                this.str = newStr;
                for(int i = 0; i < offsett; i++)
                {
                    this.str.Append('0');
                }
            }
            
        }

        public String GetString()
        {
            return this.str;
        }

        public void SetLuhn(Boolean newLuhn)
        {
            this.luhn = newLuhn;
        }

        public Boolean GetLuhn()
        {
            return this.luhn;
        }

        public int GetChecksum()
        {
            return Int32.Parse(this.str.Substring(15, 1));
        }

        public String GetStringWithZero()
        {
            return this.str.Substring(0, 15) + '0';
        }

        override public String ToString()
        {
            return this.str + ", " + this.luhn.ToString();
        }
    }
}
