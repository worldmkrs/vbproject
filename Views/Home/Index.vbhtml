@Code
    ViewData("Title") = "Home Page"
End Code




@Html.BeginForm("index", "Home", FormMethod.Post)    

<div Class="row">
    <div Class="col-sm-8 col-lg-6" style="text-align:left">
        <Label for="Brand_ID"><strong>Brand ID</strong>  </label>
        <input type = "text" value="" id="brandtext" />
    </div>
    <div Class="col-sm-8 col-lg-6" style="text-align:left">
        <Label for="Region_ID"><strong>Region ID</strong>   </label>
        <input type = "text" value="" id="regiontext"/>
    
        <input type = "submit" value="Submit" />
    </div>
</div>





