using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba.Model
{
	public class Fakultet
	{
		public List<Osoba> Osobe { get; set; } = new List<Osoba>();
		public int KolikoProfesora()
		{ 
			return Osobe.OfType<Profesor>().Count(); 
		}

		public int KolikoStudenata() 
		{ 
			return Osobe.OfType<Student>().Count(); 
		}

		public Student DohvatiStudenta(string jmbag)
		{
			return Osobe.OfType<Student>().Where(s => s.JMBAG == jmbag).FirstOrDefault();
		}

		public IEnumerable<Profesor> DohvatiProfesore()
		{
			return Osobe.OfType<Profesor>().OrderBy(p => p.DatumIzbora);
		}

		public IEnumerable<Student> DohvatiStudente91()
		{
			return Osobe.OfType<Student>().Where(s => s.DatumRodjenja.Year > 1991);
		}

		public IEnumerable<Student> DohvatiStudente91NoLinq()
		{
			List<Student> rez = new List<Student>();
			foreach (var o in Osobe)
			{
				if (o is Student)
				{
					Student s = o as Student;
					if (s.DatumRodjenja.Year > 1991)
						rez.Add(s);
				}
			}
			return rez;
		}

		public IEnumerable<Student> StudentiNeTvzD()
		{
			return Osobe.OfType<Student>()
				.Where(j => !(j.JMBAG.StartsWith("0246")) && j.Prezime.StartsWith("D"));
		}

		public List<Student> DohvatiStudente91List()
		{
			return Osobe.OfType<Student>()
				.Where(s => s.DatumRodjenja.Year >1991)
				.ToList();
		}

		public Student NajboljiProsjek(int god)
		{
			return Osobe.OfType<Student>()
				.Where(p => p.DatumRodjenja.Year  == god)
				.OrderByDescending(p => p.Prosjek)
				.FirstOrDefault();
		}

		public IEnumerable<Student> StudentiGodinaOrdered(int god)
		{
			return Osobe.OfType<Student>().Where(p => p.DatumRodjenja.Year == god)
				.OrderByDescending(p => p.Prosjek);
		}

		public IEnumerable<Profesor> SviProfesori(bool asc)
		{
			var statement = this.Osobe.OfType<Profesor>()
				.OrderBy(p => p.Prezime)
				.ThenBy(p => p.Ime);

			return asc ? statement : statement.Reverse();
		}

		public int KolikoProfesoraUZvanju(Zvanje zvanje)
		{
			return Osobe.OfType<Profesor>().Count(p => p.Zvanje == zvanje);
		}

		public IEnumerable<Profesor> NeaktivniProfesori(int x)
		{
			return Osobe.OfType<Profesor>()
				.Where(p => p.Zvanje == Zvanje.Predavac || p.Zvanje == Zvanje.VisiPredavac)
				.Where(p => p.Predmeti.Count <  x);
		}

		public IEnumerable<Profesor> AktivniAsistenti(int x, int minEcts)
		{
			return Osobe.OfType<Profesor>()
				.Where(p => p.Zvanje == Zvanje.Asistent)
				.Where(p => p.Predmeti.Count(pp => pp.ECTS >= minEcts) > x);
		}

		public void IzmjeniProfesore(Action<Profesor> action)
		{
			foreach(var prof in Osobe.OfType<Profesor>())
				action(prof);
		}

	}
}
