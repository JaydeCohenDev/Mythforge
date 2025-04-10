<script lang="ts">
    import Autocomplete from "@smui-extra/autocomplete";

    var options = ["One", "Two", "Three"];

    var value = "";
</script>

<div>
    <Autocomplete combobox {options} bind:value label="Fruit" />
    <pre class="status">Selected: {value || ""}</pre>
</div>
