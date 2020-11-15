function SetVisiblity(tid, visible) {

    var x = document.getElementById(tid);
    if (visible == true) {
        x.style.visibility = "visible";
        x.style.display = "";
    }
    else {
        x.style.visibility = "hidden";
        x.style.display = "none";
    }

}

/////////////////////////////////////////////////////////////////////////////////////

function HypF(xrow, xcol) {
    form1.DummyTextBox.value = xrow + ":" + xcol;
    form1.submit();
}

/////////////////////////////////////////////////////////////////////////////////////


/////////////////////////////////////////
function JavaPrintForm() {
    window.print();
    return false;
}
/////////////////////////////////////////

/////////////////////////////////////////
function MyKeyHandler(e) {
    var code = 0;


    if (window.event) code = e.keyCode; else code = e.which;

    if (code == 13) return false;


    return true;
}

/////////////////////////////////////////
function toggleBox(szDivID, iState) // 1 visible, 0 hidden
{
    var obj = document.layers ? document.layers[szDivID] :
        document.getElementById ? document.getElementById(szDivID).style :
            document.all[szDivID].style;

    obj.visibility = document.layers ? (iState ? "show" : "hide") :
        (iState ? "visible" : "hidden");

    obj.display = iState ? "" : "none";
}
/////////////////////////////////////////

function JustifyTable(TableName) {
    var i = 0;

    var table = document.getElementById(TableName);

    var rows = table.getElementsByTagName("tr");

    for (i = 0; i < rows.length; i++) rows[i].style.textAlign = "justify";

}


/////////////////////////////////////////
function toggleBox(szDivID, iState) // 1 visible, 0 hidden
{
    var obj = document.layers ? document.layers[szDivID] :
        document.getElementById ? document.getElementById(szDivID).style :
            document.all[szDivID].style;
    obj.visibility = document.layers ? (iState ? "show" : "hide") :
        (iState ? "visible" : "hidden");
    obj.display = iState ? "" : "none";
}
/////////////////////////////////////////


/////////////////////////////////////////
function DelemitLongNumber(str) {
    var ans = "";
    var idx = 0;

    if (str.length == 0) return "";

    for (var k = str.length - 1; k >= 0; k--) {
        idx++;
        ans += str.charAt(k);
        if ((idx % 3) == 0 && k > 0) ans += ",";
    }

    return ReverseString(ans);
}
/////////////////////////////////////////

/////////////////////////////////////////
function DlmVal(str) {
    var s;

    while (str.indexOf(",") >= 0) str = str.replace(",", "");
    return str * 1;
}
/////////////////////////////////////////

/////////////////////////////////////////
function ReverseString(str) {
    var ans = "";

    for (var k = str.length - 1; k >= 0; k--)
        ans += str.charAt(k);

    return ans;

}
/////////////////////////////////////////


/////////////////////////////////////////
function FilterNumric_Pure(e) {
    var ret = false;

    if (window.event) { if (e.keyCode >= 48 && e.keyCode <= 57) ret = true; }
    else
        if (e.which >= 48 && e.which <= 57) ret = true;

    return ret;
}
/////////////////////////////////////////


/////////////////////////////////////////
function FilterFarsi(e) {
    var ret = true;

    if (window.event) // for upper case 
    { if (e.keyCode >= 65 && e.keyCode <= 90) ret = false; }
    else
        if (e.which >= 65 && e.which <= 90) ret = false;


    if (window.event) // for lower case 
    { if (e.keyCode >= 97 && e.keyCode <= 122) ret = false; }
    else
        if (e.which >= 97 && e.which <= 122) ret = false;


    return ret;
}
/////////////////////////////////////////


/////////////////////////////////////////
function FilterNumric(e) {
    var ret = false;

    if (window.event) { if ((e.keyCode >= 48 && e.keyCode <= 57) || e.keyCode == 44) ret = true; }
    else
        if ((e.which >= 48 && e.which <= 57) || e.keyCode == 44) ret = true;

    return ret;
}
/////////////////////////////////////////



/////////////////////////////////////////////////////////////////////////////////////
function CalcSumOfTable(xtable, xcol)  // first row is header and last is footer
{
    var i = 0, j = 0;
    var sum = 0;
    var rownumber = xtable.rows.length;

    for (j = 1; j < rownumber - 1; j++)
        sum += DlmVal(xtable.rows[j].cells[xcol].innerText);

    xtable.rows[rownumber - 1].cells[xcol].innerText = DelemitLongNumber(sum + "");
}
/////////////////////////////////////////////////////////////////////////////////////


/////////////////////////////////////////////////////////////////////////////////////
function AddHyperlink2Fields(xtable, xrow, xcol, xlink) {
    xtable.rows[xrow].cells[xcol].innerHTML = "<a style=\"color: #000000;text-decoration:none\" href=\"" + xlink + "\">" + xtable.rows[xrow].cells[xcol].innerText + "</a>";
}
/////////////////////////////////////////////////////////////////////////////////////
