function onSubmit() {
    var dishObject = { name: $("#name").val(), calories: $("#calories").val(), type=$("#type option:selected").val() }
    console.log(dishObject);
}
console.log("hi from dish.js");
$("#submitDish").click(() => {
    onSubmit()
});