# HTML Helpers

- The HtmlHelper class renders HTML controls in the razor view. It binds the model object to HTML controls to display the value of model properties into those controls and also assigns the value of the controls to the model properties while submitting a web form. So always use the HtmlHelper class in razor view instead of writing HTML tags manually.

-  @Html is an object of the HtmlHelper class. (@ symbol is used to access server-side object in razor syntax). Html is a property of the HtmlHelper class included in base class of razor view WebViewPage. The ActionLink() and DisplayNameFor() are extension methods included in the HtmlHelper class

### Some Of Html Helpers
- Html.TextBoxFor()
- Html.CheckBoxFor()
- Html.RadioButtonFor()
- Html.ListBoxFor()
- Html.LabelFor()
- Html.DisplayFor()
- Html.EditorFor()

```C#
// Syntax

 @Html.ValidationSummary(true, "", new { @class = "text-danger" })
        <div class="form-group">
            @Html.LabelFor(model => model.Id, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.Id, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.Id, "", new { @class = "text-danger" })
            </div>
        </div>
```
