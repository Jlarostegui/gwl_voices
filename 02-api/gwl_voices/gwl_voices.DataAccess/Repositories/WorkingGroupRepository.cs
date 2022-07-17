using gwl_voices.DataAccess.Contracts.Dto;
using gwl_voices.DataAccess.Contracts.Repositories;
using gwl_voices.DataAccess.gwl_Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;



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
                _context.WorkingGroups
                .Where(wk => wk.Id == id)
                .Select(wk => new WorkingGroupDto { Id = wk.Id, Name = wk.Name })
                .FirstOrDefault();
                //from workingGroup in _context.WorkingGroups
                //where workingGroup.Id == id
                //select new WorkingGroupDto
                //{
                //    Id = workingGroup.Id,
                //    Name = workingGroup.Name,
                //};

            return query;
        }


        public async Task<List<WorkingGroupDto>> GetAllWorkingGroups()
        {
            try
            {
                var query = await _context.WorkingGroups
                    .Select(wg => new WorkingGroupDto { Id = wg.Id, Name = wg.Name })
                    .ToListAsync();

                return query;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public WorkingGroupDto? AddWorkingGroup(WorkingGroupDto workingGroup)
        {
            WorkingGroup newworkingGroup = new WorkingGroup
            {
                Name = workingGroup.Name
            };

            var workingGroupAdded = _context.WorkingGroups.Add(newworkingGroup);

            WorkingGroupDto result = new WorkingGroupDto
            {
                Id = workingGroupAdded.Entity.Id,
                Name = workingGroupAdded.Entity.Name
            };

            return result;

        }

        public WorkingGroupDto? UpdateWorkingGroup(WorkingGroupDto workingGroup)
        {
            WorkingGroup workingGroupToUpdate = new WorkingGroup
            {
                Id = workingGroup.Id,
                Name = workingGroup.Name
            };

            var workingGroupUpdated = _context.WorkingGroups.Update(workingGroupToUpdate);

            WorkingGroupDto result = new WorkingGroupDto
            {
                Id = workingGroupUpdated.Entity.Id,
                Name = workingGroupUpdated.Entity.Name
            };

            return result;

        }

        public void DeleteWorkinGroup(int id)
        {
            WorkingGroup workinGroupToDelete = new WorkingGroup
            {
                Id = id
            };

           _context.WorkingGroups.Remove(workinGroupToDelete);

        }


        public List<int> getUsersOfWg(int x)
        {
            var query =
                _context.TbiUserWgroups
                .Where(wk => wk.WorkingGrId == x)
                .Select(user => user.UserId)
                .ToList();


            return query;

        }






    }

}
