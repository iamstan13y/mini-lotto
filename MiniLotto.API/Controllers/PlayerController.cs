﻿using Microsoft.AspNetCore.Mvc;
using MiniLotto.API.Models.Data;
using MiniLotto.API.Models.Local;
using MiniLotto.API.Models.Repository;
using MiniLotto.API.Services;

namespace MiniLotto.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class PlayerController(IPlayerRepository playerRepository, IPlayerService playerService) : ControllerBase
{
    private readonly IPlayerRepository _playerRepository = playerRepository;
    private readonly IPlayerService _playerService = playerService;

    [HttpGet]
    public async Task<IActionResult> GetPlayers()
    {
        var result = await _playerRepository.GetAllPlayersAsync();
        return Ok(result);
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetPlayer(string name)
    {
        var result = await _playerRepository.GetPlayerAsync(name);
        if (!result.Success) return NotFound(result);

        return Ok(result);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddPlayer(PlayerRequest request)
    {
        var result = await _playerRepository.AddPlayerAsync(new Player
        {
            Name = request.Name,
            NumberSets =
            [
                new() { Numbers = request.Numbers }
            ]
        });

        if (!result.Success) return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("draw")]
    public async Task<IActionResult> RunDraw()
    {
        var drawResult = await _playerService.RunDrawAsync();
        return Ok(drawResult);
    }
}