<template>
  <div class="card">
    <img class="card-img rounded shadow action" src="https://images.unsplash.com/photo-1582139329536-e7284fece509?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1000&q=80" alt="vault image">
    <div class="card-img-overlay d-flex align-items-end justify-content-between">
      <router-link :to="{ name: 'Vault', params: {id: vault.id}}">
        <h5 class="card-title text-light text-left" title="Open vault">
          {{ vault.name }}
        </h5>
      </router-link>
    </div>
  </div>
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
    return {}
  }
}
</script>

<style lang="scss" scoped>

</style>
