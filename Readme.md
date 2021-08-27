<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128634580/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4137)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
* [Program.cs](./CS/Program.cs) (VB: [Program.vb](./VB/Program.vb))
<!-- default file list end -->
# How to display custom tooltips for appointments, resource headers and day headers


<p>This example illustrates how to display custom tooltips for appointments, resource headers and day headers. We assign a ToolTipController Class instance to the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerSchedulerControl_ToolTipControllertopic"><u>SchedulerControl.ToolTipController Property</u></a> and handle the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressUtilsToolTipController_BeforeShowtopic"><u>ToolTipController.BeforeShow Event</u></a>. In this event handler, we examine the type of the object in the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressUtilsToolTipController_ActiveObjecttopic"><u>ToolTipController.ActiveObject Property</u></a> and create a custom tooltip on the fly.</p><p><strong>See Also:</strong></p><p><a href="https://www.devexpress.com/Support/Center/p/E155">How to customize the tooltips shown for appointments</a><br />
<a href="https://www.devexpress.com/Support/Center/p/E414">How to show a tooltip for time cells in a scheduler view</a></p>

<br/>


