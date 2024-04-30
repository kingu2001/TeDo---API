
using Microsoft.AspNetCore.Mvc;
using FileService.Models;
using FileService.Data;
using AutoMapper;
using FileService.Dtos;
using System.Net.Http.Headers;

namespace FileService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SignedDocumentController : ControllerBase
{
    private readonly ISignedDocumentRepo _repo;
    private readonly IMapper _mapper;

    public SignedDocumentController(ISignedDocumentRepo signedDocumentRepo, IMapper mapper)
    {
        _repo = signedDocumentRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SignedDocument>>> GetSignedDocuments()
    {
        var result = await _repo.GetAllDocumentsAsync();
        if (result != null)
        {
            return Ok(_mapper.Map<IEnumerable<SignedDocumentReadDto>>(result));
        }
        return NotFound("No signed documents exists");
    }

    [HttpGet("{id}", Name = "GetSignedDocumentById")]
    public async Task<ActionResult<SignedDocument>> GetSignedDocumentById(int id)
    {
        var result = await _repo.GetDocumentByIdAsync(id);
        if (result != null)
        {
            return Ok(_mapper.Map<SignedDocumentReadDto>(result));

        }
        else return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<SignedDocument>> CreateSignedDocument(SignedDocumentCreateDto signedDocumentCreateDto)
    {
        var signedDocument = _mapper.Map<SignedDocument>(signedDocumentCreateDto);
        var result = await _repo.AddSignedDocumentAsync(signedDocument);
        var signedDocumentReadDto = _mapper.Map<SignedDocumentReadDto>(signedDocument);
        if (result)
        {
            return CreatedAtRoute(nameof(GetSignedDocumentById), new {signedDocumentReadDto.Id}, signedDocumentReadDto);
        }
        else return StatusCode(500, "Creation failed");
    }

    [HttpPost]
    [Route("Update")]
    public async Task<ActionResult<SignedDocument>> UpdateSignedDocument(SignedDocumentCreateDto signedDocumentCreateDto, int id)
    {
        var signedDocumentUpdateData = _mapper.Map<SignedDocument>(signedDocumentCreateDto);
        var result = await _repo.UpdateSignedDocumentAsync(signedDocumentUpdateData, id);
        if (result)
        {
            return StatusCode(204, signedDocumentUpdateData);
        }
        else return StatusCode(500);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSignedDocument(int id)
    {
        var result = await _repo.DeleteDocumentByIdAsync(id);
        if (result)
        {
            var updatedSignedDocument = await _repo.GetDocumentByIdAsync(id);
            return Ok(updatedSignedDocument);
        }
        else return NotFound();
    }
}
