using HotelSys.Interfaces;
using System;

namespace HotelSys.Objects
{
    public class CodeGenertor : ICodeGenerator
    {
        private string code = "R";
        private string newCode = "N";

        public string Generate(int id)
        {
            Random rand = new();
            this.code += id + 1 + "C";

            if (this.code.Length > 10)
            {
                int temp = this.code.Length - 10;

                if (temp < 9)
                {

                    for (int i = temp; i > 0; --i)
                    {
                        int z = Convert.ToInt32(this.code.Substring(this.code.Length - (9 + i), 1));
                        this.newCode += (char)(64 + z);
                    }
                    this.newCode += this.code.Substring(this.code.Length - 8 - temp, 9 - temp);
                    this.code = newCode;
                }
                else
                {
                    throw new StackOverflowException("Idex of reservations is out of range, can't create reservation code");
                }
            }

            for (int i = this.code.Length; i < 10; i++)
            {
                this.code += rand.Next(0, 10);
            }


            return this.code;
            }
        }
    }
