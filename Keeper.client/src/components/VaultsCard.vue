<template>
  <div class="card">
    <img class="card-img rounded shadow action" src="https://images.unsplash.com/photo-1582139329536-e7284fece509?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1000&q=80" alt="vault image">
    <div class="card-img-overlay d-flex align-items-end justify-content-between">
      <router-link :to="{ name: 'Vault', params: {id: vault.id}}">
        <h5 class="card-title text-light text-left">
          {{ vault.name }}
        </h5>
      </router-link>
      <button class="btn btn-danger" @click="deleteVault(vault.id)">
        Remove Vault
      </button>
    </div>
  </div>
</template>

<script>
import { vaultsService } from '../services/VaultsService'
import Pop from '../utils/Notifier'
export default {
  props: {
    vault: {
      type: Object,
      required: true
    }
  },

  setup() {
    return {
      async deleteVault(id) {
        try {
          if (await Pop.confirm()) {
            await vaultsService.deleteVault(id)
          }
        } catch (error) {
          Pop.toast(error, 'error')
        }
      }
    }
  }
}
</script>

<style lang="scss" scoped>
.card-title{
    text-shadow: black 1px 1px 1px;
}

</style>
