using Escola.Application.DTOs.Notas;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.Services
{
    public class NotaService: INotaService
    {
        public readonly INotaRepository _notaRepository;

        public NotaService(INotaRepository notaRepository)
        {
            _notaRepository = notaRepository;
        }

        public async Task<NotaGetDTO> AddAsync(NotaPostDTO notaDTO)
        {
            var nota = new Nota
            {
                MatriculaId = notaDTO.MatriculaId,
                ValorNota = notaDTO.ValorNota,
                Aprovado = notaDTO.ValorNota >= 60,
                DataNota = DateTime.UtcNow
            };

            var createdNota = await _notaRepository.AddAsync(nota);

            return new NotaGetDTO
            {
                Id = createdNota.Id,
                MatriculaId = createdNota.MatriculaId,
                ValorNota = createdNota.ValorNota,
                Aprovado = createdNota.Aprovado,
                DataNota = createdNota.DataNota
            };
        }

        public async Task<List<NotaGetDTO>> GetAllNotasAsync()
        {
            var notas = await _notaRepository.GetAllNotasAsync();
            return notas.Select(n => new NotaGetDTO
            {
                Id = n.Id,
                MatriculaId = n.MatriculaId,
                ValorNota = n.ValorNota,
                Aprovado = n.Aprovado,
                DataNota = n.DataNota
            }).ToList();
        }

        public async Task<NotaGetDTO> GetNotaByIdAsync(int id)
        {
            var nota = await _notaRepository.GetNotaByIdAsync(id);

            if (nota == null) return null;
            
            return new NotaGetDTO
            {
                Id = nota.Id,
                MatriculaId = nota.MatriculaId,
                ValorNota = nota.ValorNota,
                Aprovado = nota.Aprovado,
                DataNota = nota.DataNota
            };
        }

        public async Task<NotaGetDTO> UpdateAsync(NotaPutDTO notaDTO)
        {
            var nota = await _notaRepository.GetNotaByIdAsync(notaDTO.Id);

            if (nota == null) return null;

            if(notaDTO.ValorNota >= 60) nota.Aprovado = true;
            else nota.Aprovado = false;

            nota.ValorNota = notaDTO.ValorNota;
            nota.MatriculaId = notaDTO.MatriculaId;
            nota.DataNota = DateTime.UtcNow;

            return new NotaGetDTO
            {
                Id = nota.Id,
                MatriculaId = nota.MatriculaId,
                ValorNota = nota.ValorNota,
                Aprovado = nota.Aprovado,
                DataNota = nota.DataNota
            };
        }
    }
}
