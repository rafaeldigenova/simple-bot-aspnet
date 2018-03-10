using SimpleBot.Dominio;

namespace SimpleBot.Infra
{
    public static class PersistencyFactory
    {

        private static TipoDePersistencia _tipoDeBancoDeDados
        {
            get
            {
                return TipoDePersistencia.SQL;
            }
        }

        public static IUserRepo ObterRepositorioDeUsuario()
        {
            switch(_tipoDeBancoDeDados)
            {
                case TipoDePersistencia.SQL:
                    return new Persistencia.SQL.UserProfileRepo(Configuracao.ConnectionStringSql);
                case TipoDePersistencia.MongoDb:
                    return new Persistencia.MongoDB.UserProfileRepo(Configuracao.ConnectionStringMongoDB);
                default:
                    return new Persistencia.Memoria.UserProfileRepo();
            }
        } 

        public static IMessageRepo ObterRepositorioDeMensagem()
        {
            switch (_tipoDeBancoDeDados)
            {
                case TipoDePersistencia.SQL:
                    return new Persistencia.SQL.MessageRepo(Configuracao.ConnectionStringSql);
                case TipoDePersistencia.MongoDb:
                    return new Persistencia.MongoDB.MessageRepo(Configuracao.ConnectionStringMongoDB);
                default:
                    return new Persistencia.Memoria.MessageRepo();
            }
        }
    }
}