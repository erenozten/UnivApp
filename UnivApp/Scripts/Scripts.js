$(document).ready(function () {

    var myVar = 0;
    var intForCheckbox = 1;

    $("#deleteWholeButtonId").click(function () {
        intForCheckbox++;
        //$(".checkBoxForStudents").css("visibility", "hidden");
        $(".checkBoxForStudents").css("opacity", "0");

        if (intForCheckbox % 2) {
            //$(".checkBoxForStudents").css("visibility", "hidden");
            $(".checkBoxForStudents").css("opacity", '0');
            $("#saveListButton").css('opacity', '0');

        }
        else {
            //$(".checkBoxForStudents").css("visibility", "visible");
            $(".checkBoxForStudents").css('opacity', '1');
            $("#saveListButton").css('opacity', '1');
        }
    });

    function DeleteWithJSONFunc(itemID) {
        $.ajax(
            {
                type: "POST",
                url: "Json/DeleteWithJSON",
                data: JSON.stringify({
                    ID: itemID,
                }),
                contentType: "application/json",

                success: function (result) {
                }
            });
    }

    $('#saveListButton').click(function (e) {

        function SaveList() {
            var arrItem = [];
            var commaSeparateIds = "";
            var countOfItems = 0;

            $("#studentTable tr td span input[type=checkbox]").each(function (index, valHere) {
                console.log(valHere.id);

                var checkId = valHere.id;
                var arr = checkId.split("_");
                var currentCheckboxId2 = arr[1];
                var currentCheckboxId = arr[0];
                var ischecked = $("#" + checkId).is(":checked", true);
                if (ischecked) {
                    arrItem.push(currentCheckboxId);
                }
            })

            if (arrItem.length != 0) {
                commaSeparateIds = arrItem.toString();
                $.ajax({
                    url: "Student/SaveList",
                    type: "POST",
                    data: { ItemList: commaSeparateIds },
                    beforeSend: function () {
                        //parent.animate({ 'backgroundColor': '#fb6c6c' }, 300);
                    },
                    success: function (response) {
                        $.each(arrItem,
                            function (index, value) {
                                var valueAsString = value.toString();
                                countOfItems++;

                                setTimeout(function () { $('tr[name="' + valueAsString + '"]').css("opacity", "0"); },
                                    600);
                                setTimeout(function () {
                                    $('tr[name="' + valueAsString + '"]').css("background-color", "#fb6c6c");
                                });
                                setTimeout(function () { $('tr[name="' + valueAsString + '"]').remove(); }, 1300);
                            });
                        setTimeout(function () {
                            alertify.success("<span><font size='5'>✓</font></span>    You have successfully deleted " + countOfItems + " items!");
                        },
                            1350);
                    }
                }); /*burada noktalı virgül eksikmiş, koyduk.*/
            }
        }
        SaveList();
        //alert("buton, yeni bir fonksiyon tetikledi (SaveList func) ve fonksiyon başarıyla sonuçlandı");
    });
    //saveListButton bitiş

    //alert("document ready FINISH");
    //document ready FINISH
});


//document ready içinde çalışmıyor bu! createJsonFunc()
function createJsonFunc() {
    console.log("createJsonFunc içindesiniz");
    var firstMidName = $("#FirstMidName").val();
    var lastName = $("#LastName").val();
    var enrollmentDate = $("#EnrollmentDate").val();
    if (enrollmentDate == null) {
        enrollmentDate = Datetime.Today;
    }
    $.ajax(
        {
            type: "POST",
            url: "CreateWithJson",
            data: JSON.stringify({
                FirstMidName: firstMidName, //bu kısmı server'a yolluyoruz. Server'ın beklediği parametreler solda yazılı. Sağdakiler de html'den çektiğimiz değerler. Yani html'deki değereleri server'a değişkenler üzerinden yolluyoruz.
                LastName: lastName,
                EnrollmentDate: enrollmentDate,
            }),
            contentType: "application/json",
            //yukardaki contenttype ı yazmazsan çalışmıyor. Json actionresult'una ulaşamıyor. 500 internal server hatası veriyor.
            success: function(result) {
                $("#tableForJson").css("visibility", "visible");
                $("#divForJsonInfo").css("visibility", "visible");
                alertify.success("<span><font size='5'>✓</font></span>    Success!");
                $("#tableForJson").append("<tr><td>" +
                    result.FirstMidName +
                    "</td><td>" +
                    result.LastName +
                    "</td><td>");
                debugger;
            },
            error: function() {
                alertify.alert("Error! Please fill the blanks.");
            }
});
}

function setTodayDate() {
    var today = new Date();
    var dateWithoutTime = new Date(today.getFullYear(), today.getMonth(), today.getDate());
    $("#EnrollmentDate").val = dateWithoutTime;
}

$(document).ready(function () {

    $("#GetStudent").click(function () {
        var ID = $("#studentIdForInput").val();  //burada <input> tag'ı içine yazılmış olan değeri alıyoruz. Elle yazılan değeri.
        $.ajax({
            url: '/Json/getStudentJson/' + ID,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                //debugger;
                if (data) {
                    //json'dan dönen obje --> buradaki data değişkenine atanmış oldu. Bunu controller'dan dönen json objesi gibi kullanabilir, propertylerini çekebiliriz örneğin: data.FirstName, data.LastName gibi...

                    if (data.success && data.IsItInteger) {
                        $("#studentFirstMidNameId").html(data.FirstMidNameReturnedByJson);
                        $("#studentLastNameId").html(data.LastNameReturnedByJson);
                        $("#studentID").html(data.IdReturnedByJson);
                        alertify.success("<span><font size='5'>✓</font></span>    1Success!");
                        $("#spanForNotFound").html(" ");
                        var actionLinkParam = $("#studentIdForInput").val();
                        $("#hrefId").attr("href", 'Student/Edit/' + actionLinkParam);
                        $("#hrefId").html("Edit this student");
                    }

                    if (!data.success && !data.IsItInteger) {
                        alertify.alert("Please enter a valid ID! Input must contain only numbers.");
                        $("#spanForNotFound").html("Sorry! Could Not Find This Item!");
                        $("#studentFirstMidNameId").html(" -");
                        $("#studentLastNameId").html(" -");
                        $("#studentID").html(" -");
                        $("#hrefId").html(" ");
                        //debugger;
                    }

                    if (!data.success && data.IsItInteger) {
                        $("#spanForNotFound").html("Sorry! Could Not Find This Item!");
                        alertify.error("<span><font size='5'>✗</font></span>    Sorry! Could Not Find This Item!");
                        $("#studentFirstMidNameId").html(" -");
                        $("#studentLastNameId").html(" -");
                        $("#studentID").html(" -");
                        $("#hrefId").html(" ");
                        //debugger;
                    }
                    //debugger;
                }
            },
            error: function () {
                alertify.error("Error :(");
                $("#spanForNotFound").html("Error :(");
                $("#studentFirstMidNameId").html(" -");
                $("#studentLastNameId").html(" -");
                $("#studentID").html(" -");
                $("#hrefId").html(" ");
                //debugger;
            }
        });
    });
});



