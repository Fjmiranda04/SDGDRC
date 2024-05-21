namespace GeneralLedger.SelfService.Web.Areas.Identity.Data.Repository.Implements
{
    public class GenericRepositoryIdentity : IGenericRepositoryIdentity
    {
        private readonly UserDataContext userDataContext;

        public GenericRepositoryIdentity(UserDataContext userDataContext)
        {
            this.userDataContext = userDataContext;
        }

        public void ChangeConnectionString(string connectionString)
        {
            userDataContext.ChangeConnectionString(connectionString);
        }
    }
}