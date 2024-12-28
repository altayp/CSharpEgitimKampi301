using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
	public partial class FrmStatistics : Form
	{
		public FrmStatistics()
		{
			InitializeComponent();
		}

		EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();

		private void FrmStatistics_Load(object sender, EventArgs e)
		{
			lblLocationCount.Text = db.Location.Count().ToString();
			lblSumCapacity.Text = db.Location.Sum(x => x.LocationCapacity).ToString();
			lblGuideCount.Text = db.Guide.Count().ToString();
			lblAvgCapacity.Text = string.Format("{0:0.00}", db.Location.Average(x => x.LocationCapacity));
			lblAvgPrice.Text = string.Format("{0:0.00}  ₺", db.Location.Average(x => x.LocationPrice));

			int lastCountryId = db.Location.Max(x => x.LocationId);
			lblLastCountryName.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(y => y.LocationCountry).FirstOrDefault();

			lblCappadicaLocationCapacity.Text = db.Location.Where(x => x.LocationCity == "Kapadokya").Select(y => y.LocationCapacity).FirstOrDefault().ToString();
			lblTurkeyCapacityAverage.Text = db.Location.Where(x => x.LocationCountry == "Türkiye").Average(y => y.LocationCapacity).ToString();

			var romeGuideId = db.Location.Where(x => x.LocationCity == "Roma Turistik").Select(y => y.GuideId).FirstOrDefault();
			lblRomeGuideName.Text = db.Guide.Where(x => x.GuideId == romeGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();

			var maxCapacity = db.Location.Max(x => x.LocationCapacity);
			lblMaxCapacity.Text = db.Location.Where(x => x.LocationCapacity == maxCapacity).Select(y => y.LocationCity).FirstOrDefault().ToString();

			var maxPrice = db.Location.Max(x => x.LocationPrice);
			lblMaxPriceTour.Text = db.Location.Where(x => x.LocationPrice == maxPrice).Select(y => y.LocationCity).FirstOrDefault().ToString();

			var guideIdByNameAysegulCinar = db.Guide.Where(x => x.GuideName == "Ayşegül" && x.GuideSurname == "Çınar").Select(y => y.GuideId).FirstOrDefault();
			lblAysegulCinarLocationCount.Text = db.Location.Where(x => x.GuideId == guideIdByNameAysegulCinar).Count().ToString();
		}
	}
}

