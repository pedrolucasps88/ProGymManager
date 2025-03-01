namespace ProGymManager.API.Requests;

public record class AlunosRequests(string nome, string cpf, string senha, string email = null);
