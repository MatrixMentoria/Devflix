function abrirDetalhes(title) {

    $.ajax({
        method: 'post',
        url: '/Filmes/TodosDetalhes',
        data: 'nome=' + title,
        success: function (data) {
            $('.modal-detalhes').html(data);
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function AdicionarNaPlaylist(title, plays, filme) {
    $.ajax({
        method: 'post',
        url: '/Filmes/AdicionarNaPlaylist',
        data: { filmeNome: title, PlaysID: plays, imdbID: filme },
        success: function (data) {
            if (data.Success)
                toastr.success(data.Message, 'Filme adicionado com sucesso');
            else
                toastr.warning(data.Message, 'Filme nao foi adicionado.');

        },
        error: function (err) {
            console.log(err);
            // Display an error toast, with a title

        }
    });
}