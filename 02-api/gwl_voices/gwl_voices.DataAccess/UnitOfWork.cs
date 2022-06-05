using gwl_voices.DataAccess.Contracts;

namespace gwl_voices.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private heroku_7ff63ad7795b383Context _context;
        public UnitOfWork(heroku_7ff63ad7795b383Context context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

    }
}
