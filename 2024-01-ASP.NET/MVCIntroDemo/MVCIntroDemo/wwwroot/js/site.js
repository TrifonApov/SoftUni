﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function GetNumber(n) {
    let num = document.getElementById("limit").value;

    window.location = "https://localhost:7100/Home/NumberToN?count=" + n;
}