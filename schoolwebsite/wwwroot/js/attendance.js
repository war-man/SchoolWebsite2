$(document).ready(function () {
    $('#datepicker').datepicker({

        changeMonth: true,

        changeYear: true,

        dateFormat: 'MM yy',



        onClose: function () {

            var iMonth = $("#ui-datepicker-div .ui-datepicker-month :selected").val();

            var iYear = $("#ui-datepicker-div .ui-datepicker-year :selected").val();

            $(this).datepicker('setDate', new Date(iYear, iMonth, 1));

        },



        beforeShow: function () {

            if ((selDate = $(this).val()).length > 0) {

                iYear = selDate.substring(selDate.length - 4, selDate.length);

                iMonth = jQuery.inArray(selDate.substring(0, selDate.length - 5),

                    $(this).datepicker('option', 'monthNames'));

                $(this).datepicker('option', 'defaultDate', new Date(iYear, iMonth, 1));

                $(this).datepicker('setDate', new Date(iYear, iMonth, 1));

            }

        }

    });



    //var dataforpostmethod = absentdatafunction();
    $("#getdata").click(function () {
        $("#top").css("display", "block");
        $("#message").text("Loading Table...");
        $("#message2").text("Data saved Successfully");
        
        
        $.get("/Attendances/Index4",
            
            function (data) {
                           

                console.log("received data "+data);
                //Here a checkbox creater block has been made to create a 31 elements of checkbox with name
                let checkboxwithnameid = (j) => {

                    let checkboxhtml = '';
                    let identityarray = [];
                    for (i = 0; i < 31; i++) {
                        let identity = (data[j].id * 100 + i);
                        rowoftable = '<td>' + '<input type="checkbox" id="' + identity + '" name="' + identity + '" value="' + identity + '"></input>' + '</td>';
                        checkboxhtml += rowoftable;
                        console.log(identity);
                        identityarray.push(identity);
                        //console.log(checkboxhtml);

                    }
                    $("#message").css("display", "none");
                    
                    
                    

                    
                    


                    //console.log(checkboxhtml);
                    return checkboxhtml;
                }


                let indentityarrayid = () => {

                    
                    let identityarray = [];
                    for (let j = 0; j < data.length; j++) {

                        for (i = 0; i < 31; i++) {

                            let identity = (data[j].id * 100 + i);
                            console.log(identity);
                            identityarray.push(identity);



                        }
                    }
                    

                    return identityarray;
                }






                // here we implemented the previous code as a function to send the whole table with checkbox
                let checkboxmaker = () => {

                    for (j = 0; j < data.length; j++) {
                        var htmlcontent= checkboxwithnameid(j);
                        markup = "<tr><td>" + data[j].name + "</td>" + htmlcontent + "</td></tr>";
                        tableBody = $("#tablebody");
                        tableBody.append(markup);

                    }
                     
                }


                let idchecked = () => {

                    let initialarray = [];
                    let indentityarray = indentityarrayid();
                    console.log("datalength" + data.length);
                    console.log("Indentity Array " + indentityarray);
                    for (j = 0; j < indentityarray.length; j++) {
                        let tempid = '#' + indentityarray[j];

                        if ($(tempid).is(":checked")) {
                            let absentid = $(tempid).val();
                            console.log(absentid);
                            console.log('checked' + absentid);
                            initialarray.push(absentid);

                        }

                    }
                    console.log((initialarray));
                    
                    return initialarray;



                }


                //main absentdata
                let absentdatafunction = () => {
                    $("#submit").click(function () {
                        let datepicker = $("#datepicker").val();

                        console.log("datepicker " + datepicker);
                        let datepicker1 = datepicker.split(" ");
                        console.log("picker0 " + datepicker1[0])
                        console.log(typeof(datepicker1[0]))
                        console.log("picker1 " + datepicker1[1])
                        console.log(typeof(datepicker1[1]))
                        let dataofperson = idchecked();
                        let finaljson = [];
                        let tempdate = [];
                        let idarray = [];
                        let datearray = [];
                        let indexdatearray = [];
                        let finalid = [];
                        let month = datepicker1[0];
                        let year = datepicker1[1];
                        let tempdatefinal = [];
                        let alldaysofmonth = [];
                        //let tempdate2 = [];
                        let count, i;
                        

                        for (let i = 0; i < dataofperson.length; i++) {

                            let id = Math.floor(dataofperson[i] / 100);
                            console.log("i " + i);
                            console.log("id " + id);
                            let date = (dataofperson[i] - id * 100 +1);
                            console.log("date " + date);
                            idarray.push(id);
                            datearray.push(date);

                            if (idarray[i - 1] != id) {
                                indexdatearray.push(i);
                                finalid.push(id);
                            }

                        }

                        console.log(indexdatearray);
                        console.log(datearray);
                        console.log(idarray);
                        console.log(finalid);
                        let lastnumberofloop = (datearray.length) - indexdatearray[indexdatearray.length - 1]

                        

                        for (j = 0; j < indexdatearray.length; j++) {
                            if (j > 0) {

                                let numberofloop = indexdatearray[j] - indexdatearray[j - 1];

                                if (numberofloop == 1) {
                                    tempdatefinal.push(datearray[j - 1]);

                                }

                                if (numberofloop > 1) {
                                    count = 0;
                                    i = indexdatearray[j - 1];
                                    tempdate = [];
                                    while (count < numberofloop) {

                                        tempdate.push(datearray[i]);
                                        count++;
                                        i++;

                                    }
                                    tempdatefinal.push(tempdate);
                                    tempdate = [];
                                }

                                if (lastnumberofloop == 0) {
                                    tempdatefinal.push(datearray[datearray.length - 1]);

                                }

                                if (lastnumberofloop > 0 && j == (indexdatearray.length - 1)) {
                                    count = 0;
                                    i = indexdatearray[indexdatearray.length - 1];
                                    tempdate = [];

                                    while (count < lastnumberofloop) {
                                        tempdate.push(datearray[i]);
                                        count++;
                                        i++;

                                    }
                                    tempdatefinal.push(tempdate);
                                }




                            }
                        }

                        console.log("absent days only" + tempdatefinal);
                        console.log("absent data testing");
                        console.log(tempdatefinal[0]);
                        console.log(tempdatefinal[1]);
                        //converting tempdatefinal of absent days to present days
                        //Special test

                        function removeElement(array, elem) {
                            var index = array.indexOf(elem);
                            if (index > -1) {
                                array.splice(index, 1);
                            }
                        }
                        for (i = 0; i < tempdatefinal.length; i++) {
                            alldaysofmonth = [];
                            for (j = 0; j < 31; j++) {
                                alldaysofmonth.push(j + 1);
                            }
                            if (tempdatefinal[i].length == 1) {
                                let tempfinaldate_nonarray = tempdatefinal[i];
                                removeElement(alldaysofmonth, tempfinaldate_nonarray);
                                tempdatefinal[i] = alldaysofmonth;
                            }
                            if (tempdatefinal[i].length > 1) {
                                for (let k = 0; k < tempdatefinal[i].length; k++) {
                                    let tempfinaldate_nonarray = tempdatefinal[i][k];
                                    removeElement(alldaysofmonth, tempfinaldate_nonarray);
                                    
                                }
                                tempdatefinal[i] = alldaysofmonth;
                            }
                                                                                 
                           
                        }
                        console.log("Present days only" + tempdatefinal.toString());

                        //here we are going to implement the absent to present conversion code blocks

                        for (i = 0; i < finalid.length; i++) {
                            finaljson.push({
                                Studentsid: finalid[i],
                                Day: tempdatefinal[i].toString(),
                                Month: month,
                                Year: year
                            });
                            console.log("going to post");
                            $.post("Attendances/Indexdata",
                                {
                                    attendance: {
                                        Studentsid: finalid[i],
                                        Day: tempdatefinal[i].toString(),
                                        Month: month,
                                        Year: year
                                    }
                                },
                                function (status) {

                                    $("#details").css("display", "block");

                                    $("#message2").css("display", "block");

                                    //testing settimeout function

                                    setTimeout(function () {
                                        $("#message2").css("display", "none");
                                    }, 2000);
                                });
                        }
                        console.log(finaljson);

                        //for testing purpose to see what data is sent please comment this lines after testing
                        console.log("###############    Testing Started    ##########");
                                                
                        
                        

                        return finaljson;

                        
                    });
                }

                checkboxmaker();

                absentdatafunction();

            });

                  

    });

});