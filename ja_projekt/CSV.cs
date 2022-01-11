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
        private bool validLuhn = false;

        public CSV(String newStr, Boolean newValidLuhn)
        {
            this.SetString(newStr);
            this.SetValidLuhn(newValidLuhn);
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

        public void SetValidLuhn(Boolean newValidLuhn)
        {
            this.validLuhn = newValidLuhn;
        }

        public Boolean GetValidLuhn()
        {
            return this.validLuhn;
        }

        override public String ToString()
        {
            return this.str + ", " + this.validLuhn.ToString();
        }
    }
}
