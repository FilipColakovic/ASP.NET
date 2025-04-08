using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba.Model
{
	public class Profesor : Osoba
	{
		public string Odjel { get; set; }
		public Zvanje Zvanje { get; set; }
		public DateTime DatumIzbora { get; set; }

		public List<Predmet> Predmeti { get; set; } = new List<Predmet>();

		public int KolikoDoReizbora()
		{
			int yearsToAdd = (Zvanje == Zvanje.Asistent) ? 4 : 5;
			DateTime reizborDate = DatumIzbora.AddYears(yearsToAdd);
			int yearsRemaining = (int)((reizborDate - DateTime.Now).TotalDays / 365);
			return yearsRemaining;
		}
	}

	public enum Zvanje
	{
		Asistent,
		Docent,
		RedovitiProfesor,
		VisiAsistent,
		ProfVisokeSkole,
		Predavac,
		VisiPredavac
	}
}
