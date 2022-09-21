namespace APIcomDynamoDB
{
    public interface IDynamoRepository
    {
        Pessoa CreateOnDb(Pessoa pessoa);

        Task<Pessoa> GetOnDb(int id);
    }
}
