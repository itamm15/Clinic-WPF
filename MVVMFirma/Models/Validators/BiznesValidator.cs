using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.Validators
{
    public class BiznesValidator
    {
        public static string SprawdzVAT(decimal? VAT)
        {
            try
            {
                if (VAT < 0 || VAT > 100)
                {
                    return "VAT powinien byc w przedziale 0-100.";
                }
            }
            catch (Exception ex) { }
            return null;
        }

        public static string SprawdzCena(decimal? Cena)
        {
            try
            {
                if (Cena < 0)
                {
                    return "Podana kwota nie może być mniejsza niż zero!";
                }
            } catch (Exception e) { };

            return null;
        }
    }
}
