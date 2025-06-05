<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Document.ascx.cs" Inherits="MeghalayaUIP.Document" %>
<div style="height:600px;">
    <object id="docViewer" data='<%# DocumentUrl %>' type="application/pdf" width="100%" height="100%">
        <p>Your browser does not support PDFs. 
        <a href='<%# DocumentUrl %>' target="_blank">Download PDF</a>.
        </p>
    </object>
</div>