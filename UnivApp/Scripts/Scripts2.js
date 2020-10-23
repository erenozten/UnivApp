
$(document).ready(function () {
    
    var buttonsaveRadioButtonCourses = document.getElementById("buttonsaveRadioButtonCourses");
    var dropDownListForInstructor = document.getElementById("dropDownListForInstructor");
    var ballGreenForSelectInstructor = document.getElementById("ballGreenForSelectInstructor");
    var ballgreenForCreateInstructorWithForm = document.getElementById("ballgreenForCreateInstructorWithForm");
    var buttonCreateInstructorWithForm = document.getElementById("buttonCreateInstructorWithForm");
    var tableRadioButtons = document.getElementById("tableRadioButtons");
    var ballGreenForSaveRadioButtonCoursesId = document.getElementById("ballGreenForSaveRadioButtonCoursesId");

    $(tableRadioButtons).css('pointer-events', 'none');
    $(buttonCreateInstructorWithForm).css('pointer-events', 'none');

    //var inputForInstructorName = document.getElementById("inputForInstructorName"); //func içinde kullanılınca undefined geliyor
    //var inputForInstructorLastName = document.getElementById("inputForInstructorLastName"); //func içinde kullanılınca undefined geliyor

    //function addOption() {
    //    var instructorNameFromInput = $(inputForInstructorName).val();
    //    var instructorLastNameFromButton = $(inputForInstructorLastName).val();
    //    var fullNameInJquery = instructorNameFromInput + " " + instructorLastNameFromButton;
    //    $(dropDownListForInstructor).append(`<option value="${instructorNameFromInput}"> 
    //                                   ${fullNameInJquery} 
    //                              </option>`);
    //    debugger;
    //}

    $(dropDownListForInstructor).change(function () {
        $(tableRadioButtons).css('pointer-events', 'auto');
        $(ballGreenForSelectInstructor).addClass("ballGreen");
        $(dropDownListForInstructor).prop("disabled", true);

        $('input[type="checkbox"]').each(function () {
            //$(this).removeAttr("checked"); //doesn't work
            $(this).prop('checked', false);
        });
        var selectedCheckboxHtml = $(dropDownListForInstructor).children("option:selected").html();

        if (selectedCheckboxHtml == "Choose Instructor") {
            $(ballGreenForSelectInstructor).removeClass("ballGreen");
            $(dropDownListForInstructor).prop("disabled", false);
            $(tableRadioButtons).css({ opacity: 0 });
            $(tableRadioButtons).css('pointer-events', 'none');
            return;
        }
        debugger;
        populateRadioButtons(); 
        debugger;

    });

    function populateRadioButtons() {
        var instructorIdFromDropDown = $(dropDownListForInstructor).children("option:selected").val();
        debugger;
        function executeAjax() {
            $.ajax(
                {
                    type: "POST",
                    url: "Json/GetInstructorIdAndPostCoursesJson",
                    data: JSON.stringify({
                        instructorIdInActionResult: instructorIdFromDropDown
                    }),
                    contentType: "application/json",
                    success: function (data) {
                        $(ballGreenForSelectInstructor).removeClass("ballGreen");
                        $(dropDownListForInstructor).prop("disabled", false);
                        $(tableRadioButtons).css({ opacity: 1 });
                        var assignedCoursesIdListInJquery = data.assignedCoursesIdListReturnedByJson;

                        $.each($(assignedCoursesIdListInJquery), function (index, idInList) {
                            $('input[type="checkbox"]').each(function () {
                                var idOfCheckBox = $(this).attr("id");
                                if (idOfCheckBox == idInList) {
                                    $(this).prop('checked', true);
                                }
                            });
                        });
                    },
                    error: function (data) {
                        alertify.error("Bir şeyler ters gitti!!!");
                        debugger;
                        $(ballGreenForSelectInstructor).removeClass("ballGreen");
                        $(dropDownListForInstructor).prop("disabled", false);
                    }
                });
        }
        window.setTimeout(executeAjax, 1000);
    };

    function saveRadioButtonCoursesJquery() {
        $(ballGreenForSaveRadioButtonCoursesId).addClass("ballGreen1");
        var idsOfRadioButtonsArray = [];
        var commaSeparateIds = "";
        var instructorIdInJquery = $(dropDownListForInstructor).children("option:selected").val();
        $.each($("input[type='checkbox']:checked"), function () {
            idsOfRadioButtonsArray.push($(this).val());
        });
        commaSeparateIds = idsOfRadioButtonsArray.toString();
        function executeAjax() {
            $.ajax(
                {
                    type: "POST",
                    url: "Json/SaveRadioButtonCoursesJson",
                    data: JSON.stringify({
                        radioButtonCoursesIdListInActionResult: commaSeparateIds,
                        instructorIdInActionResult: instructorIdInJquery
                    }),
                    contentType: "application/json",
                    success: function (data) {
                        alertify.success("<span><font size='5'>✓</font></span>    Success");
                        $(dropDownListForInstructor).prop("disabled", false);
                        $(tableRadioButtons).css({ opacity: 1 });
                        $(ballGreenForSaveRadioButtonCoursesId).removeClass("ballGreen1");
                        $(buttonsaveRadioButtonCourses).prop("disabled", false);
                        var assignedCoursesIdListInJquery = data.assignedCoursesIdListReturnedByJson;
                        $.each($(assignedCoursesIdListInJquery), function (index, idInList) {
                        });
                    },
                    error: function (data) {
                        $(buttonsaveRadioButtonCourses).removeClass("ballGreen1");
                        alertify.error("Bir şeyler ters gitti!");
                        $(buttonsaveRadioButtonCourses).prop("disabled", false);
                    }
                });
        }
        executeAjax();
    };

    $(buttonsaveRadioButtonCourses).click(function () {
        $(ballGreenForSaveRadioButtonCoursesId).addClass("ballGreen1"); 
        $(buttonsaveRadioButtonCourses).prop("disabled", true);
        window.setTimeout(saveRadioButtonCoursesJquery, 1000);
    });

    function populateEmptyRadioButtons() {
        var instructorIdFromDropDown = $(dropDownListForInstructor).children("option:selected").val();
        $(ballGreenForSelectInstructor).removeClass("ballGreen1"); 
        $(dropDownListForInstructor).prop("disabled", false);
        $(tableRadioButtons).css({ opacity: 1 });

        $('input[type="checkbox"]').each(function () {
            //$(this).removeAttr("checked");
            $(this).prop('checked', false);
        });
    };

    $("#buttonToggleNameSurnameForm").click(function buttonToggleNameSurnameForm() {

        var gelenDeger = parseInt($("#formHorizontal").attr("hiddenNumber")); 
        gelenDeger++; 
        $("#formHorizontal").attr("hiddenNumber", gelenDeger); 
        if (gelenDeger % 2 === 1) {
            $("#parent").append("#divForNewForm");
            $(buttonCreateInstructorWithForm).css({ opacity: 1 });
            $(buttonCreateInstructorWithForm).css('pointer-events', 'auto');

            $("#divForNewForm").append(
                "<div id='firstOne' class='form-group'>" +
                "<label class='control-label col-md-3'>" +
                "<span>First Name</span>" +
                "</label>" +
                "<div class='col-md-6'>" +
                "<input id='inputForInstructorName' class='form-control text-box single-line valid'>" +
                "</div>" +
                "</div>" +

                "<div id='secondOne' class='form-group'>" +
                "<label class='control-label col-md-3'>" +
                "<span>Last Name</span>" +
                "</label>" +
                "<div class='col-md-6'>" +
                "<input id='inputForInstructorLastName' class='form-control text-box single-line valid'>" +
                "</div>" +
                "</div>");
        }

        //<div class="form-group">
        //<label class="control-label col-md-3"><span></span></label>
        //    <div class="col-md-6" style="
        //margin-top: -13px !important;
        //">
        //    <label style="color:red">Bu alan boş bırakılamaz!</label>
        //    </div>
        //</div>

        if (gelenDeger % 2 === 0) {
            //$("#divForNewForm").remove();
            $(buttonCreateInstructorWithForm).css({ opacity: 0 });
            $("#divForNewForm").empty();
            $(buttonCreateInstructorWithForm).css('pointer-events', 'none');
            debugger;
        }
    });

    function createInstructorWithJsonFunc() {

        var inputForInstructorName = document.getElementById("inputForInstructorName");
        var inputForInstructorLastName = document.getElementById("inputForInstructorLastName");

        $(buttonCreateInstructorWithForm).attr("disabled", true);
        var instructorNameFromInput = $(inputForInstructorName).val();  
        var instructorLastNameFromInput = $(inputForInstructorLastName).val();
        function executeAjax() {
            $.ajax(
                {
                    type: "POST",
                    url: "Json/GetInstructorDataJson",
                    data: JSON.stringify({
                        instructorNameInActionResult: instructorNameFromInput,
                        instructorLastNameInActionResult: instructorLastNameFromInput
                    }),
                    contentType: "application/json",
                    success: function (data) {
                        if (data.isNameOrLastNameNull) {
                            alertify.alert(data.message);
                            $(ballgreenForCreateInstructorWithForm).removeClass("ballGreen1ToTheLeft");
                            $(buttonCreateInstructorWithForm).attr("disabled", false);
                            console.log(buttonCreateInstructorWithForm);
                        }

                        if (data.isNewInstructorCreated) {
                            populateEmptyRadioButtons();
                            var newInstructorIdInJquery = data.newInstructorIdReturnedByJson;
                            var fullNameInJquery = instructorNameFromInput + " " + instructorLastNameFromInput;
                            alertify.success(data.message);

                            $(dropDownListForInstructor).append(`<option selected="selected" value="${data.instructorHere.ID}"> 
                                       ${data.instructorHere.FullName} 
                                  </option>`);

                            $(ballgreenForCreateInstructorWithForm).removeClass("ballGreen1ToTheLeft");
                            $(buttonCreateInstructorWithForm).attr("disabled", false);
                            alertify.success(message);
                            $(inputForInstructorName).val("");
                            $(inputForInstructorLastName).val("");
                            alert(data.message);
                        }
                    },
                    error: function (data) {
                        $(ballgreenForCreateInstructorWithForm).removeClass("ballGreen1ToTheLeft");
                        $(buttonCreateInstructorWithForm).attr("disabled", false);
                        alert(data.message);
                    }
                });
        }
        executeAjax();
    };

    $(buttonCreateInstructorWithForm).click(function (event) {

        var inputForInstructorName = document.getElementById("inputForInstructorName"); //func içinde kullanılınca undefined geliyor
        var inputForInstructorLastName = document.getElementById("inputForInstructorLastName"); //func içinde kullanılınca undefined geliyor

        var InstructorNameValueLength = $(inputForInstructorName).val().length;
        var InstructorLastNameValueLength = $(inputForInstructorLastName).val().length;

        if (InstructorNameValueLength == 0 || InstructorLastNameValueLength == 0) {
            createInstructorWithJsonFunc();
        }
        if (InstructorNameValueLength != 0 && InstructorLastNameValueLength != 0) {
            $(ballgreenForCreateInstructorWithForm).addClass("ballGreen1ToTheLeft");
            $(ballgreenForCreateInstructorWithForm).prop("disabled", true);
            window.setTimeout(createInstructorWithJsonFunc, 1000);
        }
        //if (asdf.length != 0) {
        //    window.setTimeout(createInstructorWithJsonFunc, 1000);
        //    debugger;
        //}
    });

});





