using RoyalGames.Applications.Conversoes;
using RoyalGames.Domains;
using RoyalGames.DTOs.Jogo;
using RoyalGames.DTOs.Produto;
using RoyalGames.Exceptions;
using RoyalGames.Interfaces;

namespace RoyalGames.Applications.Services
{
    public class JogoService
    {
        private readonly IJogoRepository _repository;

        public JogoService(IJogoRepository repository)
        {
            _repository = repository;
        }

        public List<LerJogoDto> Listar()
        {
            List<Jogo> jogos = _repository.Listar();

            List<LerJogoDto> jogoDto = jogos.Select(JogoParaDto.ConverterParaDto).ToList();

            return jogoDto;
        }

        public LerJogoDto ObterPorId(int id)
        {
            Jogo jogo = _repository.ObterPorId(id);

            if (jogo == null)
            {
                throw new DomainException("Jogo não encontrado.");
            }

            return JogoParaDto.ConverterParaDto(jogo);
        }

        private static void ValidarCadastro(CriarJogoDto jogoDto)
        {
            if (string.IsNullOrWhiteSpace(jogoDto.Nome))
            {
                throw new DomainException("Nome é obrigatório.");
            }
            if (jogoDto.Preco < 0)
            {
                throw new DomainException("Preço deve ser maior que zero.");
            }
            if (string.IsNullOrWhiteSpace(jogoDto.Descricao))
            {
                throw new DomainException("Descrição é obrigatória.");
            }
            if (jogoDto.Imagem == null || jogoDto.Imagem.Length == 0)
            {
                throw new DomainException("Imagem é obrigatória.");
            }
            if (jogoDto.GeneroIds == null || jogoDto.GeneroIds.Count() == 0)
            {
                throw new DomainException("O jogo deve ter ao menos um gênero");
            }
            if (jogoDto.PlataformaIds == null || jogoDto.PlataformaIds.Count() == 0)
            {
                throw new DomainException("O jogo deve ter ao menos uma plataforma.");
            }
        }

        public byte[] ObterImagem(int id)
        {
            var imagem = _repository.ObterImagem(id);

            if(imagem == null || imagem.Length == 0)
            {
                throw new DomainException("Imagem não encontrada.");
            }

            return imagem;
        }

        public LerJogoDto Adicionar(CriarJogoDto jogoDto, int usuarioId)
        {
            ValidarCadastro(jogoDto);

            if (_repository.NomeExiste(jogoDto.Nome))
            {
                throw new DomainException("Jogo já existente.");
            }

            Jogo jogo = new Jogo()
            {
                Nome = jogoDto.Nome,
                Preco = jogoDto.Preco,
                Descricao = jogoDto.Descricao,
                Imagem = ImagemParaBytes.ConverterImagem(jogoDto.Imagem),
                StatusJogo = true,
                FK_UsuarioID = usuarioId
            };

            _repository.Adicionar(jogo, jogoDto.GeneroIds);
            _repository.Adicionar(jogo, jogoDto.PlataformaIds);

            return JogoParaDto.ConverterParaDto(jogo);
        }
    }
}
