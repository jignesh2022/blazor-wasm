
export function formatDoc(cmd, value) {
    //event.preventDefault();
    var editor = document.getElementById("editor");
    editor.focus();
    //var doc = editor.ownerDocument;
    //var sel = doc.getSelection();
    //alert(sel.toString());
    //console.log(sel.toString());
    //console.log(sel)
    //event.preventDefault();
    console.log(window.getSelection().toString());
    //document.queryCommandState("bold");
    var done = document.execCommand(cmd, false, value);
    
    console.log(done);
    //console.log(valid); 
    
} 

export function openBrowse(id) {
    var openDialog = document.getElementById(id);    
    openDialog.click();
}
