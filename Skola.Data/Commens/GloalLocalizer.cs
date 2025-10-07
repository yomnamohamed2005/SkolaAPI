using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Data.Commens
{
	public class GlobalLocalizaleEntity
	{
		public  string Localize(string TextAr , string TextEn)
		{
			CultureInfo culture = Thread.CurrentThread.CurrentCulture;
			if (culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
				return TextAr;
			return TextEn;
		}
	}
}
 