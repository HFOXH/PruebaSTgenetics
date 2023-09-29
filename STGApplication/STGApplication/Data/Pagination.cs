using Microsoft.EntityFrameworkCore;

namespace STGApplication.Data
{
    public class Pagination<T> : List<T>
    {
        public int MainPage { get; private set; }
        public int TotalPages { get; private set; }
        public Pagination(List<T> items, int counter, int mainPage, int cantData) {
            MainPage = mainPage;
            TotalPages = (int)Math.Ceiling(counter / (double)cantData);

            this.AddRange(items);
        }
        public bool BeforePages => MainPage > 1;
        public bool AfterPages => MainPage < TotalPages;
        public static async Task<Pagination<T>> MakePagination(IQueryable<T> source, int mainPage, int cantData) {
            var counter = await source.CountAsync();
            var items = await source.Skip((mainPage - 1) * cantData).Take(cantData).ToListAsync();
            return new Pagination<T>(items, counter, mainPage, cantData);
        }
    }
}
