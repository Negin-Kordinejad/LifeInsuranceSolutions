
function DateStruct() { this.iyear = this.imonth = this.iday = 0; }



function XDate(y, m, d) {

    this.dt = new DateStruct;

    if (y != null) {
        this.dt.iyear = y;
        this.dt.imonth = m;
        this.dt.iday = d;
    }
    else {
        var x = new Date();

        this.dt = jdn_persian(civil_jdn(x.getFullYear(), x.getMonth() + 1, x.getDate()));
    }

    this.getFullYear = getFullYear;
    this.getMonth = getMonth;
    this.getDate = getDate;
    this.setDate = setDate;
    this.getDay = getDay;

    function getFullYear() { return this.dt.iyear; }
    function getMonth() { return this.dt.imonth; }
    function getDate() { return this.dt.iday; }

    function getDay() {
        var tmp = jdn_civil(persian_jdn(this.dt.iyear, this.dt.imonth, this.dt.iday));
        var x = new Date(tmp.iyear, tmp.imonth - 1, tmp.iday);
        var day = x.getDay() + 1;
        if (day == 7) day = 0;
        return day;
    }

    function setDate(d) {
        if (this.dt.imonth >= 1 && this.dt.imonth <= 6) if (d <= 31) this.dt.iday = d; else { this.dt.iday = 1; this.dt.imonth++; }
        if (this.dt.imonth >= 7 && this.dt.imonth <= 11) if (d <= 30) this.dt.iday = d; else { this.dt.iday = 1; this.dt.imonth++; }
        if (this.dt.imonth == 12) if (d <= 29) this.dt.iday = d; else { this.dt.iday = 1; this.dt.imonth++; }
        if (this.dt.imonth > 12) { this.dt.imonth = 1; this.dt.iyear++; }
    }




}

////////////////////////////////////////////////////
function persian_jdn(iYear, iMonth, iDay) {
    var PERSIAN_EPOCH = 1948321;
    var epbase = 0; var epyear = 0; var mdays = 0; var ret = 0;

    if (iYear >= 0) epbase = iYear - 474; else epbase = iYear - 473;

    epyear = 474 + (epbase % 2820);

    if (iMonth <= 7) mdays = (iMonth - 1) * 31; else mdays = (iMonth - 1) * 30 + 6;

    return iDay + mdays + Math.floor(((epyear * 682) - 110) / 2816) + (epyear - 1) * 365 + Math.floor(epbase / 2820) * 1029983 + (PERSIAN_EPOCH - 1);
}
////////////////////////////////////////////////////




////////////////////////////////////////////////////
function jdn_persian(jdn) {
    var depoch = 0; var cycle = 0; var cyear = 0; var ycycle = 0; var aux1 = 0; var aux2 = 0; var yday = 0;
    var ret = new DateStruct();


    depoch = jdn - persian_jdn(475, 1, 1);
    cycle = parseInt(depoch / 1029983);
    cyear = depoch % 1029983;
    if (cyear == 1029982)
        ycycle = 2820;
    else {
        aux1 = parseInt(cyear / 366);
        aux2 = cyear % 366;

        ycycle = parseInt(((2134 * aux1) + (2816 * aux2) + 2815) / 1028522) + aux1 + 1
    }
    ret.iyear = ycycle + (2820 * cycle) + 474
    if (ret.iyear <= 0)
        ret.iyear = ret.iyear - 1;

    yday = (jdn - persian_jdn(ret.iyear, 1, 1)) + 1
    if (yday <= 186)
        ret.imonth = Math.ceil(yday / 31);
    else
        ret.imonth = Math.ceil((yday - 6) / 30);

    ret.iday = (jdn - persian_jdn(ret.iyear, ret.imonth, 1)) + 1;

    return ret;

}
////////////////////////////////////////////////////





/////////////////////////////////////////////////////
function jdn_julian(jdn) {
    var l = 0; var k = 0; var n = 0; var i = 0; var j = 0;
    var ret = new DateStruct();

    j = jdn + 1402;
    k = parseInt((j - 1) / 1461);
    l = j - 1461 * k;
    n = parseInt((l - 1) / 365) - parseInt(l / 1461);
    i = l - 365 * n + 30;
    j = parseInt((80 * i) / 2447);
    ret.iDay = i - parseInt((2447 * j) / 80);
    i = parseInt(j / 11);
    ret.iMonth = j + 2 - 12 * i;
    ret.iYear = 4 * k + n + i - 4716;

    return ret;
}
////////////////////////////////////////////////////





////////////////////////////////////////////////////
function jdn_civil(jdn) {
    var l = 0; var k = 0; var n = 0; var i = 0; var j = 0;
    var ret = new DateStruct();

    if (jdn > 2299160) {
        l = jdn + 68569;
        n = parseInt((4 * l) / 146097);
        l = l - parseInt((146097 * n + 3) / 4);
        i = parseInt((4000 * (l + 1)) / 1461001);
        l = l - parseInt((1461 * i) / 4) + 31;
        j = parseInt((80 * l) / 2447);
        ret.iday = l - parseInt((2447 * j) / 80);
        l = parseInt(j / 11);
        ret.imonth = j + 2 - 12 * l
        ret.iyear = 100 * (n - 49) + i + l
    }
    else
        return jdn_julian(jdn)

    return ret;
}
////////////////////////////////////////////////////

function MygetDateString(d) {
    var s = "";
    s = d.iyear + "/" + (d.imonth + 1) + "/" + d.iday;
    return s;
}

////////////////////////////////////////////////////
function MyGetDate() {
    var dt = new Date();

    var jdn = civil_jdn(dt.getFullYear(), dt.getMonth(), dt.getDate());

    return jdn_persian(jdn);
}
////////////////////////////////////////////////////


////////////////////////////////////////////////////
function MygetFieldDate(dateString) {
    var dateVal;
    var d, m, y;

    dateVal = new DateStruct();

    try {
        var dArray = dateString.split("/");
        if (dArray) {
            dateVal.iyear = parseInt(dArray[0], 10);
            dateVal.imonth = parseInt(dArray[1], 10) - 1;
            dateVal.iday = parseInt(dArray[2], 10);
        }
        else dateVal = MyGetDate();

    } catch (e) {
        dateVal = MyGetDate();
    }
    return dateVal;
}
////////////////////////////////////////////////////




////////////////////////////////////////////////////
function civil_jdn(lYear, lMonth, lDay) {
    return parseInt((1461 * (lYear + 4800 + parseInt((lMonth - 14) / 12))) / 4) + parseInt((367 * (lMonth - 2 - 12 * (parseInt((lMonth - 14) / 12)))) / 12) - parseInt((3 * (parseInt((lYear + 4900 + parseInt((lMonth - 14) / 12)) / 100))) / 4) + lDay - 32075;
}
////////////////////////////////////////////////////

