namespace ProGymManager.API.Requests;

public record class FuncionariosRequest(string nome, string cpf, string senha, string email = null);
