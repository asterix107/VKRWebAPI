namespace VKRWebAPI.Clients
{
    public class ShowBD
    {
        private readonly ContextBD Context;

        private readonly InfoContextDB InfoDB;

        public ShowBD (ContextBD contextBD, InfoContextDB infoDB)
        {
            Context = contextBD;
            InfoDB = infoDB;
        }


        public List<Clients> ShowItem()
        {
            return Context.Clients.ToList();
        }

        public List<Inform> ShowItemInfo()
        {
         return InfoDB.Informs.ToList();
        }
    }
}
