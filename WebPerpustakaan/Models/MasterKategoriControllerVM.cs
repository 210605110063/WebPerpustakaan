using WebPerpustakaan.Models.EF;

namespace WebPerpustakaan.Models
{
    public class MasterKategoriControllerVM
    {
        public class Index
        {
            public List<Models.EF.Kategori> DataKategori { get; set; } = new List<EF.Kategori>();

            public Index()
            {
                var context = new ModelContext();

                DataKategori = context.Kategoris.ToList();
            }
        }
        public class Add
        {
            public Models.EF.Kategori NewRow { get; set; } = new Kategori();

            public Add()
            {

            }
        }

        public static void Save(Add input)
        {
            if (string.IsNullOrEmpty(input.NewRow.NamaKategori))
            {
                throw new Exception("isi nama");
            }

            var _addToDb = new EF.Kategori();
            _addToDb.NamaKategori = input.NewRow.NamaKategori;

            var context = new ModelContext();
            context.Kategoris.Add(_addToDb);
            context.SaveChanges();
        }
    }
}
