$(function () {

    // confirm deletions
    $('.confirm').click(function () {
        return confirm('Are you sure?');
    });

    // select all on focus
    $('input[type=number]').click(function () {
        $(this).select();
    });
});