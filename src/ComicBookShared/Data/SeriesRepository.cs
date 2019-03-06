using ComicBookShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ComicBookShared.Data
{
    public class SeriesRepository : BaseRepository<Series>
    {
        const string SeriesListKey = "SeriesList";

        public SeriesRepository(Context context) 
            : base(context)
        {
        }

        public override Series Get(int id, bool includeRelatedEntities = true)
        {
            var series = Context.Series.AsQueryable();

            if (includeRelatedEntities)
            {
                series = series
                    .Include(s => s.ComicBooks);
            }

            return series
                .Where(cb => cb.Id == id)
                .SingleOrDefault();
        }

        public override IList<Series> GetList()
        {
            var seriesList = EntityCache.Get<List<Series>> (SeriesListKey);
            if (seriesList == null)
            {
                seriesList = Context.Series
                    .OrderBy(s => s.Title)
                    .ToList();
                EntityCache.Add(SeriesListKey, seriesList);
            }

            return seriesList;

        }
        public override void Add(Series entity)
        {
            base.Add(entity);
            EntityCache.Remove(SeriesListKey);
        }

        public override void Update(Series entity)
        {
            base.Update(entity);
            EntityCache.Remove(SeriesListKey);
        }
        public override void Delete(int id)
        {
            base.Delete(id);
            EntityCache.Remove(SeriesListKey);
        }

        public bool SeriesHasTitle(int seriesId, string title)
        {
            return Context.Series
                .Any(s => s.Id != seriesId && s.Title == title);
        }
    }
}
