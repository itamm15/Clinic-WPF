using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.Validators
{
    public class StringValidator
    {
        public static string SprawdzCzyZaczynaSieOdDuzej(string wartosc)
        {
            try
            {
                if(!char.IsUpper(wartosc, 0))
                {
                    return "Rozpocznij duza litera";
                }
            }
            catch (Exception ex) { }

            return null;
        }

        public static string SprawdzKod(string kod)
        {
            try
            {   
                if (kod != null && kod.Length < 4)
                {
                    return "Kod powinien mieć minimum 4 znaki.";
                }
            } catch (Exception e) { }

            return null;
        }
    }
}
