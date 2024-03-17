<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCDECAdmin.ascx.cs" Inherits="Admin_UCDECAdmin" %>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js" type="text/javascript"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.js" type="text/javascript"></script>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.css" />
<style type="text/css">
    #menubar {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
}

/* Make jQuery UI Menu into a horizontal menubar with vertical dropdown */
#menubar > li { /* Menubar buttons */
  display: inline-block;
}
#menubar > li > ul > li { /* Menubar buttons inside dropdown */
  display: block;
}

/* Change dropdown carets to correct direction */
#menubar > li > div > span.ui-icon-caret-1-e {
  /* Caret on menubar */
  background:url(https://www.drupal.org/files/issues/ui-icons-222222-256x240.png) no-repeat -64px -16px !important;
}
#menubar ul li div span.ui-icon-caret-1-e {
  /* Caret on dropdowns */
  background:url(https://www.drupal.org/files/issues/ui-icons-222222-256x240.png) no-repeat -32px -16px !important;
}
</style>
<ul id="menubar">
  <li><div>Alpha</div></li>
  <li>
    <div>Beta</div>
    <ul>
      <li><div>Beta 1</div></li>
      <li>
        <div>Beta 2</div>
        <ul>
          <li><div>Beta 2a</div></li>
          <li><div>Beta 2b</div></li>
        </ul>
      </li>
      <li><div>Beta 3</div></li>
    </ul>
  </li>
  <li><div>Gamma</div></li>
  <li><div>Delta</div></li>
</ul>

<script type="text/javascript">
    $(document).ready(function() {
  $('#menubar').menu();
  
  $('#menubar').menu({
    position: { my: 'left top', at: 'left bottom' },
    blur: function() {
      $(this).menu('option', 'position', { my: 'left top', at: 'left bottom' });
    },
    focus: function(e, ui) {
      if ($('#menubar').get(0) !== $(ui).get(0).item.parent().get(0)) {
        $(this).menu('option', 'position', { my: 'left top', at: 'right top' });
      }
    },
  });
});
</script>