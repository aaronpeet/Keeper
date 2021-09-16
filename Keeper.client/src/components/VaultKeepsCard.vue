<template>
  <div class="card">
    <img class="card-img rounded shadow" :src="vaultkeep.img" alt="keep image">
    <div class="card-img-overlay d-flex align-items-end justify-content-between">
      <button v-if="vaultkeep.creatorId == account.id" class="btn btn-danger" @click="deleteVaultKeep(vaultkeep.id)">
        Remove
      </button>
      <h5 class="card-title text-light text-left">
        {{ vaultkeep.name }}
      </h5>
      <img class="rounded-pill" :src="vaultkeep.creator.picture" alt="keep creator image">
    </div>
  </div>
</template>

<script>
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
import Pop from '../utils/Notifier'
import { vaultKeepsService } from '../services/VaultKeepsService'
export default {
  props: {
    vaultkeep: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    return {
      account: computed(() => AppState.account),
      async deleteVaultKeep() {
        try {
          await vaultKeepsService.deleteVaultKeep(props.vaultkeep.id)
        } catch (error) {
          Pop.toast(error, 'error')
        }
      }
    }
  }
}
</script>

<style lang="scss" scoped>
.rounded-pill{
    max-height: 40px;
}
.card-title{
    text-shadow: black 1px 1px 1px;
}

</style>
