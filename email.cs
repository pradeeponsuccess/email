        ------Web Config---------
        <add key="Host" value="smtp.gmail.com"/>
        <add key="Port" value="587"/>
        <add key="SSL" value="true"/>
        <add key="FromEmail" value="Email@gmail.com"/>
        <add key="Username" value="Email@gmail.com"/>
        <add key="Password" value="password"/>
        -----------------------------
        
        
        -----CS CODE--------------------
        using (MailMessage mm = new MailMessage(ConfigurationManager.AppSettings["FromEmail"], getinlst.Email))
                    {
                         mm.Subject = "Subject";
                        string body = string.Empty;
                        using (StreamReader reader = new StreamReader(Server.MapPath("~/Project_Readme.html")))
                        {
                            body = reader.ReadToEnd();
                        }
                        body = body.Replace("{UserName}", getinlst.Email);
                        body = body.Replace("{StudentName}", getinlst.Student_Name);
                        body = body.Replace("{TXNAMT}", data.TXNAMOUNT);
                        body = body.Replace("{CourseName}", getinlst.AppliedCourse);
                        body = body.Replace("{Password}", getinlst.Password);
                        mm.Body = body;
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = ConfigurationManager.AppSettings["Host"];
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"]);
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                        smtp.Send(mm);
                    }
                    --------------------------------
                    ----------------Project_Readme.html File---------------------------------
                    
                    <!DOCTYPE html>
<html lang="en">
<head>

    <meta charset="utf-8" />
    <title>Your ASP.NET application</title>
    <style type="text/css">
        @import url(http://fonts.googleapis.com/css?family=Lato:400,700);
        .profile {
            font-family: 'Lato', 'sans-serif';
        }
        .profile {
            /*    height: 321px;
    width: 265px;*/
            margin-top: 2px;
            padding: 1px;
            display: inline-block;
        }
        .divider {
            border-top: 1px solid rgba(0,0,0,0.1);
        }
        .emphasis {
            border-top: 1px solid transparent;
        }
            .emphasis h2 {
                margin-bottom: 0;
            }
        span.tags {
            background: #1abc9c;
            border-radius: 2px;
            color: #f5f5f5;
            font-weight: bold;
            padding: 2px 4px;
        }
        .profile strong, span, div {
            text-transform: initial;
        }
    </style>
</head>
<body>

    <div id="header">
        <h5>Hello..!!!!! {UserName}</h5>
        <p>Congratulations! You've created a project</p>
    </div>

    
    <div class="container">
        <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="border-radius: 16px;">
                        <div class="well profile col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                                <figure>
                                    <img src="http://www.localcrimenews.com/wp-content/uploads/2013/07/default-user-icon-profile.png" alt="" class="img-circle" style="width:75px;" id="user-img">
                                </figure>
                                <h5 style="text-align:center;"><strong id="user-name">{StudentName}</strong></h5>
                                <p style="text-align:center;font-size: smaller;" id="user-frid"><strong>Paid Amount: </strong>{TXNAMT}</p>
                                <p style="text-align:center;font-size: smaller;overflow-wrap: break-word;" id="user-email"> {UserName} </p>
                                <p style="text-align:center;font-size: smaller;"><strong>A/C status: </strong><span class="tags" id="user-status">Active</span></p>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 divider text-center"></div>
                                <p style="text-align:center;font-size: smaller;"><strong>Applied Course</strong></p>
                                <p style="text-align:center;font-size: smaller;" id="user-role">{CourseName}</p>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 divider text-center"></div>
                                <div class="col-lg-6 left" style="text-align:center;overflow-wrap: break-word;">
                                    <h4><p style="text-align: center;"><strong id="user-globe-rank">User Name</strong></p></h4>
                                    <p><small class="label label-success">{UserName}</small></p>
                                    <!--<button class="btn btn-success btn-block"><span class="fa fa-plus-circle"></span> Follow </button>-->
                                </div>
                                <div class=" col-lg-6 left" style="text-align:center;overflow-wrap: break-word;">
                                    <h4><p style="text-align: center;"><strong id="user-college-rank">Password </strong></p></h4>
                                    <p> <small class="label label-warning">{Password}</small></p>
                                    <!-- <button class="btn btn-info btn-block"><span class="fa fa-user"></span> View Profile </button>-->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
   

</body>
</html>
