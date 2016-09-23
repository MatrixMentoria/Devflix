function abrirDetalhes(title, imdb) {

    $.ajax({
        method: 'post',
        url: '/Filmes/TodosDetalhes',
        data: 'nome=' + title,
        success: function (data) {
            $('.modal-detalhes').html(data);
            $('#' + imdb).modal('show');
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

function CriarPlaylist(title) {
    $.ajax({
        method: 'post',
        url: '/Usuario/CriarPlaylist',
        data: { titulo: title },
        success: function (data) {
            if (data.Success)
                toastr.success(data.Message, 'Playlist adicionada com sucesso');
            else
                toastr.warning(data.Message, 'Playlist nao foi adicionado.');

        },
        error: function (err) {
            console.log(err);
            // Display an error toast, with a title

        }
    });
}