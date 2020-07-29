function contains(a, obj) {
    for(var i = 0; i < a.length; i++) {
        if (a[i]=== obj) {
            return true;
        }
    }
    return false;
}
function filter(id, table, column) {
    // Declare variables 
    var input, filter, table, tr, td, i;
    input = document.getElementById(id);
    filter = input.value.toUpperCase();
    table = document.getElementById(table);
    tr = table.getElementsByTagName("tr");
    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[column];
        if (td) {
            if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}
function DeleteRegister(ID, Message, URL,Table) {
    console.log("ID:" + ID, " Message:" + Message + " URL:" + URL + " Table:" + Table);
    if (confirm(Message)) {
        console.log("ID:"+ID," Message:"+Message +" URL:"+URL+" Table:"+Table);
        $.ajax({
            url: URL,
            type: 'POST',
            data: {id:ID},
            success: function (result) {
                if (result.error == "none") {
                    var TR = document.getElementById(ID);
                    $(Table).dataTable().fnDeleteRow(TR);
                    
                    
                }
                else {
                    alert("Hubo un error:" + result.Message);
                }
            }
        });
    }
}
function OpenModal(URL) {
    $(".se-pre-con").fadeIn();
    
    $('#myModal').load(URL, function () {
        $(".se-pre-con").delay(5).fadeOut("slow");
    });
}
