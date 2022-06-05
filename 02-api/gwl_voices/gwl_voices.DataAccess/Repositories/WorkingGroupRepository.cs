using gwl_voices.DataAccess.Contracts.Dto;
using gwl_voices.DataAccess.Contracts.Repositories;

namespace gwl_voices.DataAccess.Repositories
{
    public class WorkingGroupRepository : IWorkingGroupRepository

    {
        private heroku_7ff63ad7795b383Context _context;
        public WorkingGroupRepository(heroku_7ff63ad7795b383Context context)
        {
            _context = context;
        }

        public WorkingGroupDto? GetWorkingGroupById(int id)
        {
            var query =
                from workingGroup in _context.WorkingGroups
                where workingGroup.Id == id
                select new WorkingGroupDto
                {
                    Id = workingGroup.Id,
                    Name = workingGroup.Name,
                };
            
            return query.FirstOrDefault();
      
        }
    }

}
