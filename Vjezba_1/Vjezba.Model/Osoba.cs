using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba.Model
{
	public class Osoba
	{
		public string Ime { get; set; }
		public string Prezime { get; set; }
		private string _oib;
		public string OIB
		{
			get { return _oib; }

			set
			{
				if (value.Length != 11 || !value.All(char.IsDigit))
					throw new InvalidOperationException();
				_oib = value;
			}
		}
		private string _jmbg { get; set; }
		public string JMBG 
		{
			get { return _jmbg; }
			set
			{
				if (value.Length != 13 || !value.All(char.IsDigit))
					throw new InvalidOperationException();
				_jmbg = value;
			}
		}
		
		public DateTime DatumRodjenja
		{
			get
			{
				int godina = int.Parse(_jmbg.Substring(4, 3));
				int mjesec = int.Parse(_jmbg.Substring(2, 2));
				int dan = int.Parse(_jmbg.Substring(0, 2));
				if (godina < 1100)
					godina += 1000;
	
				return new DateTime(godina, mjesec, dan);
			}
		}
	}
}
