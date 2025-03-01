namespace ProGymManager.API.Requests;

public record class PersonaisRequests(string nome, string cpf, string senha, string email = null);
