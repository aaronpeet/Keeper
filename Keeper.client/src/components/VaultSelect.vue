<template>
  <button @click="createVaultKeep(vault.id)" class="dropdown-item" type="button">
    {{ vault.name }}
  </button>
</template>

<script>
export default {
  props: {
    vault: {
      type: Object,
      required: true
    }
  },
  setup() {
    return {
    }
  }
}
</script>

<style lang="scss" scoped>

</style>
