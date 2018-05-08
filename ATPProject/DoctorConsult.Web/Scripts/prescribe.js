$(document).ready(function () {
    $("#PrescribtionDate").empty(); $("#NextVisitDate").empty(); $('.mydatepicker').datepicker({ format: 'mm/dd/yyyy' }); $('#btnSubmit').click(function (e) {
        e.preventDefault(); if (submitValidator()) { var medicineArr = []; var testArr = []; var referDoctor = document.getElementById("ReferToAnotherDr").value; var referDiagonstic = document.getElementById("ReferDiagnostic").value; var prescriptionDate = document.getElementById("PrescribtionDate").value; var nextvisitDate = document.getElementById("PrescribtionDate").value; var cause = document.getElementById("Cause").value; var comment = document.getElementById("Comment").value; var patientId = $("#btnSubmit").attr("data-patient-id"); $.each($("#MedicineTable tbody tr"), function () { medicineArr.push({ Name: $(this).find('td:eq(0)').html(), Quantity: parseInt($(this).find('td:eq(1)').html()), Days: parseInt($(this).find('td:eq(2)').html()), DailyTimes: $(this).find('td:eq(3)').html() }) }); $.each($("#TestTable tbody tr"), function () { testArr.push({ TestName: $(this).find('td:eq(0)').html() }) }); var data = JSON.stringify({ PrescribtionDate: prescriptionDate, NextVisitDate: nextvisitDate, Comment: comment, PatientId: patientId, Cause: cause, ReferDoctor: referDoctor, ReferDiagonstics: referDiagonstic, Medicines: medicineArr, MedicalTests: testArr }); console.log(data); $.when(savePres(data)).then(function (response) { console.log(response); location.href = "/Doctor/PrescribtionList" }).fail(function (err) { console.log(err.error) }) }
        else { console.log("fail to submit forms") }
    }); $('#btnAddMedicine').click(function (e) { if (MedicineAddValidator()) { var name = document.getElementById("name").value; console.log(name); var days = parseInt(document.getElementById("days").value); console.log(days); var daytimevalue = parseInt(document.getElementById("DayTime").value); var daytimeText = $("#DayTime option:selected").text(); var detailsTableBody = $("#MedicineTable tbody"); var row = `<tr><td>${name} </td> <td> ${days * daytimevalue} </td> <td> ${days}</td> <td>${daytimeText} </td> <td> <a data-itemId="0" href="#" class="deleteItem"><i class="fa fa-trash"></i></a></td></tr>  `; detailsTableBody.append(row); $('#name').val(''); $('#days').val('') } }); $(document).on('click', 'a.deleteItem', function (e) { e.preventDefault(); $(this).parents('tr').css("background-color", "#1f306f").fadeOut(800, function () { $(this).remove() }) }); $('#btnAddTest').click(function (e) {
        var name = document.getElementById("Testname").value; if (name == "")
            document.getElementById("error_Testname").style.display = "block"; else { var detailsTableBody = $("#TestTable tbody"); var row = `<tr><td>${name} </td> <td> <a data-itemId="0" href="#" class="testdeleteItem"><i class="fa fa-trash"></i></a></td></tr>  `; detailsTableBody.append(row); $('#Testname').val('') }
    }); $(document).on('click', 'a.testdeleteItem', function (e) { e.preventDefault(); $(this).parents('tr').css("background-color", "#1f306f").fadeOut(800, function () { $(this).remove() }) })
}); function savePres(data) { return $.ajax({ contentType: 'application/json; charset=utf-8', dataType: 'json', type: 'POST', url: "/Doctor/Prescribtion", data: data }) }
function submitValidator() {
    var prescriptionDate = document.getElementById("PrescribtionDate").value; var cause = document.getElementById("Cause").value; var comment = document.getElementById("Comment").value; if (prescriptionDate === "" || cause === "" || comment === "") {
        if (prescriptionDate === "") { document.getElementById("error_PrescribtionDate").style.display = "block" }
        else { document.getElementById("error_PrescribtionDate").style.display = "none" }
        if (cause === "") { document.getElementById("error_Cause").style.display = "block" }
        else { document.getElementById("error_Cause").style.display = "none" }
        if (comment === "") { document.getElementById("error_Comment").style.display = "block" }
        else { document.getElementById("error_Comment").style.display = "none" }
        return !1
    }
    else { return !0 }
}
function MedicineAddValidator() {
    var name = document.getElementById("name").value; var days = document.getElementById("days").value; if (name === "" || days === "") {
        if (name === "") { document.getElementById("error_name").style.display = "block" }
        else { document.getElementById("error_name").style.display = "none" }
        if (days === "") { document.getElementById("error_days").style.display = "block" }
        else { document.getElementById("error_days").style.display = "none" }
        return !1
    }
    else { return !0 }
}
function blankme(id) {
    var val = document.getElementById(id).value; var error_id = "error_" + id; if (val == "" || val === 0.00) { document.getElementById(error_id).style.display = "block" }
    else { document.getElementById(error_id).style.display = "none" }
}